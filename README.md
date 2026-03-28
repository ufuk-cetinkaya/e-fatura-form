# EFaturaForm

.NET 10 ve C# 14 kullanılarak geliştirilmiş, dış bağımlılığı olmayan (standalone) bir E-Fatura oluşturma ve görüntüleme masaüstü uygulamasıdır.

Bu uygulama, kullanıcıdan aldığı verileri Gelir İdaresi Başkanlığı (GİB) standartlarına uygun UBL 2.1 formatında XML dosyalarına dönüştürür, mevcut XML'leri görselleştirir ve API entegrasyonu sağlar.

🚀 Öne Çıkan Özellikler
UBL 2.1 Uyumluluğu: GİB formatına tam uyumlu fatura XML (UBL) oluşturma.

Tersine Eşleme (Mapping): Kayıtlı XML dosyalarını tekrar uygulamaya yükleyerek form bileşenlerine otomatik veri dağıtımı.

XSLT & HTML Dönüşümü: XML içerisine gömülü XSLT şablonlarını kullanarak faturayı HTML formatına dönüştürme ve tarayıcıda önizleme.

Bağımsız Çalışma: Herhangi bir veritabanı, NuGet paketi veya harici kütüphane gerektirmez.

API Entegrasyonu: Oluşturulan XML verisini, binary data kabul eden herhangi bir uç noktaya (endpoint) doğrudan gönderebilme.

Hafif ve Hızlı: Windows Forms mimarisi sayesinde düşük kaynak tüketimi ve yüksek performans.

🛠 Teknik Detaylar

Framework: .NET 10

Dil: C# 14

IDE: Visual Studio 2026

Mimari: Windows Forms (WinForms)

Bağımlılıklar: Sıfır (Zero-dependency)

💻 Kurulum ve Çalıştırma
Proje herhangi bir kurulum gerektirmez. Visual Studio 2026 ile solution dosyasını açıp derlemeniz yeterlidir.

Repoyu klonlayın:
git clone https://github.com/ufuk-cetinkaya/e-fatura-form.git

🛠 Gereksinimler ve Derleme
Bu proje, herhangi bir IDE bağımlılığı olmaksızın derlenebilir. Ancak derleme işlemi için sisteminizde .NET 10 SDK yüklü olmalıdır.

SDK Kontrolü: Terminale şu komutu yazarak yüklü sürümü kontrol edebilirsiniz:
dotnet --version

Derleme:
dotnet build EFaturaForm.slnx -c Release

Derleme sonrası executable dosyasına bin/Release/net10.0-windows/ klasöründen erişebilirsiniz.

Visual Studio Görsel arayüz üzerinden devam etmek isterseniz:
1. EFaturaForm.slnx dosyasını çift tıklayarak açın.
2. F6 (Build Solution) ile projeyi derleyin.
3. F5 ile uygulamayı başlatın.

📖 Kullanım
Fatura Oluşturma: Form üzerindeki alanları (Alıcı bilgileri, kalemler, vergi oranları vb.) doldurun ve "Kaydet" butonuna basın.

Düzenleme: Daha önce oluşturduğunuz bir XML dosyasını "Aç" diyerek içeri aktarın; tüm veriler forma otomatik olarak dolacaktır.

Önizleme: "Görüntüle" seçeneği ile faturanın HTML halini varsayılan tarayıcınızda inceleyin.

Gönderim: API ayarlarını yapılandırarak faturayı tek tıkla ilgili servise iletin.

📄 Lisans
Bu proje MIT lisansı altında lisanslanmıştır.
