using System.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace EFaturaForm;

public partial class EFaturaListele : Form
{
    private readonly HttpClient _client;

    public EFaturaListele()
    {
        InitializeComponent();
        FillDirection(direction);

        _client = InsecureHttpClient();
        _client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("DocumentApiUrl") ??
            throw new InvalidOperationException("API adresi bildirilmelidir."));
    }

    private void Create_Click(object sender, EventArgs e)
    {
        EFaturaOlustur fatura = new();
        fatura.Show();
    }

    private async void Cancel_Click(object sender, EventArgs e)
    {
        try
        {
            string? ettn = invoiceList.CurrentRow?.Cells["Ettn"].Value?.ToString();
            string requestUri = $"cancel/{ettn}";
            HttpRequestMessage request = new(HttpMethod.Delete, requestUri);
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Fatura iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fatura iptal edilemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fatura listesi alınamadı. API bağlantısını kontrol ediniz.",
                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.CreateDirectory("log");
            File.AppendAllText("log/error.log", ex.StackTrace);
        }
    }

    private async void List_Click(object sender, EventArgs e)
    {
        try
        {
            string requestUri = $"?documenttype=INVOICE&direction={direction.SelectedValue}&startdate={startDate.Value}&enddate={endDate.Value}";
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new()
                {
                    PropertyNameCaseInsensitive = true
                };
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                List<DocumentDto>? documents = JsonSerializer.Deserialize<List<DocumentDto>>(jsonResponse, options);
                invoiceList.DataSource = documents;
            }
            else
            {
                MessageBox.Show("Filtereye uygun kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fatura listesi alınamadı. API bağlantısını kontrol ediniz.",
                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.CreateDirectory("log");
            File.AppendAllText("log/error.log", ex.StackTrace);
        }
    }

    private void View_Click(object sender, EventArgs e)
    {
        try
        {
            string? ettn = invoiceList.CurrentRow?.Cells["Ettn"].Value?.ToString();
            string requestUri = $"preview/{ettn}/html";
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            HttpResponseMessage response = _client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string htmlContent = response.Content.ReadAsStringAsync().Result;
                string htmlPath = $"invoice/{ettn}.html";
                File.WriteAllText(htmlPath, htmlContent);
                Preview(htmlPath);
            }
            else
            {
                MessageBox.Show("Fatura önizlemesi alınamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fatura listesi alınamadı. API bağlantısını kontrol ediniz.",
                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.CreateDirectory("log");
            File.AppendAllText("log/error.log", ex.StackTrace);
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
}
