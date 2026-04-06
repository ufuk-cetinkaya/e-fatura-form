using System.Configuration;
using System.Text;
using System.Text.Json;

namespace EFaturaForm;

public partial class GirisYap : Form
{
    public string Token { get; private set; }

    private readonly HttpClient _client;

    public GirisYap()
    {
        InitializeComponent();

        _client = InsecureHttpClient();
        _client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ApiUrl") ??
            throw new Exception("API adresi bildirilmelidir."));
    }

    private async void Login_Click(object sender, EventArgs e)
    {
        HttpRequestMessage request = new(HttpMethod.Post, "/auth/login")
        {
            Content = new StringContent(JsonSerializer.Serialize(
                new LoginRequest(username.Text, password.Text)),
                Encoding.UTF8, "application/json")
        };

        HttpResponseMessage response = await _client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            LoginResponse? loginResponse = JsonSerializer.Deserialize<LoginResponse>(jsonResponse);
            Token = loginResponse?.accessToken ?? throw new Exception("Token alınamadı.");
            MessageBox.Show("Giriş başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
        else
        {
            MessageBox.Show("Giriş başarısız. Lütfen bilgilerinizi kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        Close();
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
}

public record LoginRequest(string Email, string Password);
public record LoginResponse(string accessToken);
