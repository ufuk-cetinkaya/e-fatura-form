using EFaturaForm.Model;
using System.Configuration;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Text.Json;

namespace EFaturaForm;

public partial class EFaturaListele : Form
{
    private string _token = "";
    private readonly HttpClient _client;

    public EFaturaListele()
    {
        InitializeComponent();

        FillDirection(direction);

        _client = InsecureHttpClient();
        _client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ApiUrl") ??
            throw new Exception("API adresi bildirilmelidir."));

        Login();

        pageSize.SelectedIndex = 0;
    }

    private void Create_Click(object sender, EventArgs e)
    {
        EFaturaOlustur fatura = new(_token);
        fatura.Show();
    }

    private async void Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            string? ettn = invoiceList.CurrentRow?.Cells["Ettn"].Value?.ToString();
            string requestUri = $"/document/cancel/{ettn}";
            HttpRequestMessage request = new(HttpMethod.Delete, requestUri);
            request.Headers.Add("Authorization", $"Bearer {_token}");
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Fatura iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Giriş yaptıktan sonra tekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Fatura iptal edilemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            GlobalError(ex.StackTrace);
        }
    }

    private async void List_Click(object sender, EventArgs e)
    {
        await List();
    }

    private async void View_Click(object sender, EventArgs e)
    {
        try
        {
            string? ettn = invoiceList.CurrentRow?.Cells["Ettn"].Value?.ToString();
            string requestUri = $"/document/preview/{ettn}/html";
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Add("Authorization", $"Bearer {_token}");
            request.Headers.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
            HttpResponseMessage response = _client.Send(request);
            if (response.IsSuccessStatusCode)
            {
                string htmlContent;
                if (response.Content.Headers.ContentEncoding.Contains("gzip"))
                {
                    using Stream responseStream = response.Content.ReadAsStream();
                    using GZipStream decompressionStream = new(responseStream, CompressionMode.Decompress);
                    using StreamReader reader = new(decompressionStream);
                    htmlContent = reader.ReadToEnd();
                }
                else
                {
                    htmlContent = await response.Content.ReadAsStringAsync();
                }
                string htmlPath = $"invoice/{ettn}.html";
                Directory.CreateDirectory("invoice");
                File.WriteAllText(htmlPath, htmlContent);
                Preview(htmlPath);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Giriş yaptıktan sonra tekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Fatura önizlemesi alınamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            GlobalError(ex.StackTrace);
        }
    }

    private static void Preview(string htmlPath)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), htmlPath);
        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        });
    }

    private static HttpClient InsecureHttpClient()
    {
        HttpClientHandler handler = new()
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback =
            (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            }
        };
        return new HttpClient(handler);
    }

    private static void FillDirection(ComboBox c)
    {
        Item[] items =
            [
        new Item("IN", "Gelen"),
        new Item("OUT", "Giden")
            ];
        c.DataSource = items;
        c.ValueMember = "Id";
        c.DisplayMember = "Ad";
    }

    private void Clear_Click(object sender, EventArgs e)
    {
        invoiceList.DataSource = null;
    }

    private void Login_Click(object sender, EventArgs e)
    {
        Login();
    }

    private void Login ()
    {
        GirisYap login = new();
        if (login.ShowDialog() == DialogResult.OK)
        {
            _token = login.Token;
        }
    }

    private async Task List()
    {
        try
        {
            string requestUri = $"/document?documenttype=INVOICE&direction={direction.SelectedValue}&startdate={startDate.Value}&enddate={endDate.Value}&page={page.Text}&pagesize={pageSize.Text}";
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Add("Authorization", $"Bearer {_token}");
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new()
                {
                    PropertyNameCaseInsensitive = true
                };
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Page? page = JsonSerializer.Deserialize<Page>(jsonResponse, options);
                first.Enabled = !page.IsFirstPage;
                previous.Enabled = page.HasPreviousPage;
                next.Enabled = page.HasNextPage;
                last.Enabled = !page.IsLastPage;
                totalRecords.Text = $"Toplam Kayıt: {page.TotalRecords}";
                pageCount.Text = $"Toplam Sayfa: {page.PageCount}";
                invoiceList.DataSource = page.Data;
                if (page.Data == null || page.Data.Count() == 0)
                {
                    MessageBox.Show("Kriterlere uygun kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Giriş yaptıktan sonra tekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            GlobalError(ex.StackTrace);
        }
    }

    private static void GlobalError(string? message)
    {
        MessageBox.Show("Servisle bağlantı kurulamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Directory.CreateDirectory("log");
        File.AppendAllText("log/error.log", message);
    }

    private void First_Click(object sender, EventArgs e)
    {
        page.Text = "1";
    }

    private void Previous_Click(object sender, EventArgs e)
    {
        if (int.TryParse(page.Text, out int currentPage) && currentPage > 1)
        {
            page.Text = (currentPage - 1).ToString();
        }
    }

    private void Next_Click(object sender, EventArgs e)
    {
        if (int.TryParse(page.Text, out int currentPage))
        {
            page.Text = (currentPage + 1).ToString();
        }
    }

    private void Last_Click(object sender, EventArgs e)
    {
        if (int.TryParse(pageCount.Text.Replace("Toplam Sayfa: ", ""), out int totalPages))
        {
            page.Text = totalPages.ToString();
        }
    }

    private async void Page_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(page.Text, out int pageNumber) && pageNumber > 0)
        {
            await List();
        }
    }

    private async void PageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.TryParse(pageSize.Text, out int _))
        {
            page.Text = "1";
            await List();
        }
    }
}
