namespace EFaturaForm;

partial class EFaturaOlustur
{
    /// <summary>
    ///Gerekli tasarımcı değişkeni.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///Kullanılan tüm kaynakları temizleyin.
    /// </summary>
    ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer üretilen kod

    /// <summary>
    /// Tasarımcı desteği için gerekli metot - bu metodun 
    ///içeriğini kod düzenleyici ile değiştirmeyin.
    /// </summary>
    private void InitializeComponent()
    {
        groupBox2 = new GroupBox();
        musteriIlce = new ComboBox();
        musteriSehir = new ComboBox();
        label23 = new Label();
        label21 = new Label();
        label19 = new Label();
        label16 = new Label();
        label15 = new Label();
        label14 = new Label();
        label9 = new Label();
        label8 = new Label();
        label7 = new Label();
        label6 = new Label();
        musteriVergiDairesi = new TextBox();
        musteriEposta = new TextBox();
        musteriTelefon = new TextBox();
        musteriAdres = new TextBox();
        musteriSoyad = new TextBox();
        musteriAd = new TextBox();
        musteriUnvan = new TextBox();
        musteriVergiNo = new TextBox();
        groupBox3 = new GroupBox();
        istisnaKodu = new ComboBox();
        label41 = new Label();
        gonderimSekli = new ComboBox();
        label40 = new Label();
        label30 = new Label();
        faturaTipi = new ComboBox();
        faturaZamani = new DateTimePicker();
        senaryo = new ComboBox();
        label35 = new Label();
        faturaNo = new TextBox();
        paraBirimi = new ComboBox();
        faturaTarihi = new DateTimePicker();
        dovizKuru = new TextBox();
        label28 = new Label();
        label29 = new Label();
        label25 = new Label();
        label27 = new Label();
        label26 = new Label();
        ettn = new Label();
        label24 = new Label();
        groupBox4 = new GroupBox();
        siparisTarihi = new DateTimePicker();
        siparisNumarasi = new TextBox();
        label31 = new Label();
        label33 = new Label();
        groupBox8 = new GroupBox();
        label1 = new Label();
        odenecekTutar = new Label();
        label2 = new Label();
        toplamIskonto = new Label();
        label5 = new Label();
        malHizmetToplamTutari = new Label();
        vergilerDahilToplamTutar = new Label();
        hesaplananKdv = new Label();
        label3 = new Label();
        label4 = new Label();
        groupBox5 = new GroupBox();
        irsaliyeTarihi = new DateTimePicker();
        irsaliyeNumarasi = new TextBox();
        label32 = new Label();
        label34 = new Label();
        groupBox7 = new GroupBox();
        not = new TextBox();
        satir = new DataGridView();
        siraNo = new DataGridViewTextBoxColumn();
        malHizmet = new DataGridViewTextBoxColumn();
        miktar = new DataGridViewTextBoxColumn();
        olcu = new DataGridViewComboBoxColumn();
        birimFiyat = new DataGridViewTextBoxColumn();
        kdvOrani = new DataGridViewTextBoxColumn();
        kdvTutari = new DataGridViewTextBoxColumn();
        iskontoOrani = new DataGridViewTextBoxColumn();
        iskontoTutari = new DataGridViewTextBoxColumn();
        malHizmetTutari = new DataGridViewTextBoxColumn();
        gonder = new Button();
        groupBox1 = new GroupBox();
        saticiSehir = new ComboBox();
        saticiIlce = new ComboBox();
        label10 = new Label();
        label11 = new Label();
        label12 = new Label();
        label13 = new Label();
        label17 = new Label();
        label18 = new Label();
        label20 = new Label();
        label22 = new Label();
        label36 = new Label();
        label37 = new Label();
        saticiVergiDairesi = new TextBox();
        saticiEposta = new TextBox();
        saticiTelefon = new TextBox();
        saticiAdres = new TextBox();
        saticiSoyad = new TextBox();
        saticiAd = new TextBox();
        saticiUnvan = new TextBox();
        saticiVergiNo = new TextBox();
        groupBox6 = new GroupBox();
        iadeFaturaTarihi = new DateTimePicker();
        iadeFaturaNo = new TextBox();
        label38 = new Label();
        label39 = new Label();
        kaydet = new Button();
        goruntule = new Button();
        ac = new Button();
        temizle = new Button();
        sablonSec = new Button();
        groupBox9 = new GroupBox();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox4.SuspendLayout();
        groupBox8.SuspendLayout();
        groupBox5.SuspendLayout();
        groupBox7.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)satir).BeginInit();
        groupBox1.SuspendLayout();
        groupBox6.SuspendLayout();
        groupBox9.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(musteriIlce);
        groupBox2.Controls.Add(musteriSehir);
        groupBox2.Controls.Add(label23);
        groupBox2.Controls.Add(label21);
        groupBox2.Controls.Add(label19);
        groupBox2.Controls.Add(label16);
        groupBox2.Controls.Add(label15);
        groupBox2.Controls.Add(label14);
        groupBox2.Controls.Add(label9);
        groupBox2.Controls.Add(label8);
        groupBox2.Controls.Add(label7);
        groupBox2.Controls.Add(label6);
        groupBox2.Controls.Add(musteriVergiDairesi);
        groupBox2.Controls.Add(musteriEposta);
        groupBox2.Controls.Add(musteriTelefon);
        groupBox2.Controls.Add(musteriAdres);
        groupBox2.Controls.Add(musteriSoyad);
        groupBox2.Controls.Add(musteriAd);
        groupBox2.Controls.Add(musteriUnvan);
        groupBox2.Controls.Add(musteriVergiNo);
        groupBox2.Location = new Point(12, 152);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(450, 150);
        groupBox2.TabIndex = 2;
        groupBox2.TabStop = false;
        groupBox2.Text = "Müşteri Bilgileri";
        // 
        // musteriIlce
        // 
        musteriIlce.FormattingEnabled = true;
        musteriIlce.Location = new Point(310, 121);
        musteriIlce.Name = "musteriIlce";
        musteriIlce.Size = new Size(132, 23);
        musteriIlce.TabIndex = 10;
        // 
        // musteriSehir
        // 
        musteriSehir.FormattingEnabled = true;
        musteriSehir.Location = new Point(310, 96);
        musteriSehir.Name = "musteriSehir";
        musteriSehir.Size = new Size(132, 23);
        musteriSehir.TabIndex = 9;
        musteriSehir.SelectedIndexChanged += MusteriSehir_SelectedIndexChanged;
        // 
        // label23
        // 
        label23.AutoSize = true;
        label23.Location = new Point(3, 124);
        label23.Name = "label23";
        label23.Size = new Size(71, 15);
        label23.TabIndex = 34;
        label23.Text = "Vergi Dairesi";
        // 
        // label21
        // 
        label21.AutoSize = true;
        label21.Location = new Point(240, 53);
        label21.Name = "label21";
        label21.Size = new Size(47, 15);
        label21.TabIndex = 30;
        label21.Text = "e-Posta";
        // 
        // label19
        // 
        label19.AutoSize = true;
        label19.Location = new Point(240, 25);
        label19.Name = "label19";
        label19.Size = new Size(45, 15);
        label19.TabIndex = 26;
        label19.Text = "Telefon";
        // 
        // label16
        // 
        label16.AutoSize = true;
        label16.Location = new Point(238, 100);
        label16.Name = "label16";
        label16.Size = new Size(33, 15);
        label16.TabIndex = 20;
        label16.Text = "Şehir";
        // 
        // label15
        // 
        label15.AutoSize = true;
        label15.Location = new Point(238, 124);
        label15.Name = "label15";
        label15.Size = new Size(25, 15);
        label15.TabIndex = 18;
        label15.Text = "İlçe";
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(240, 77);
        label14.Name = "label14";
        label14.Size = new Size(37, 15);
        label14.TabIndex = 8;
        label14.Text = "Adres";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(3, 99);
        label9.Name = "label9";
        label9.Size = new Size(39, 15);
        label9.TabIndex = 6;
        label9.Text = "Soyad";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(4, 73);
        label8.Name = "label8";
        label8.Size = new Size(22, 15);
        label8.TabIndex = 4;
        label8.Text = "Ad";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(4, 50);
        label7.Name = "label7";
        label7.Size = new Size(41, 15);
        label7.TabIndex = 2;
        label7.Text = "Ünvan";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(4, 25);
        label6.Name = "label6";
        label6.Size = new Size(87, 15);
        label6.TabIndex = 0;
        label6.Text = "Vergi Numarası";
        // 
        // musteriVergiDairesi
        // 
        musteriVergiDairesi.Location = new Point(93, 121);
        musteriVergiDairesi.MaxLength = 50;
        musteriVergiDairesi.Name = "musteriVergiDairesi";
        musteriVergiDairesi.Size = new Size(132, 23);
        musteriVergiDairesi.TabIndex = 5;
        // 
        // musteriEposta
        // 
        musteriEposta.Location = new Point(310, 45);
        musteriEposta.MaxLength = 50;
        musteriEposta.Name = "musteriEposta";
        musteriEposta.Size = new Size(132, 23);
        musteriEposta.TabIndex = 7;
        // 
        // musteriTelefon
        // 
        musteriTelefon.Location = new Point(310, 19);
        musteriTelefon.MaxLength = 20;
        musteriTelefon.Name = "musteriTelefon";
        musteriTelefon.Size = new Size(132, 23);
        musteriTelefon.TabIndex = 6;
        // 
        // musteriAdres
        // 
        musteriAdres.Location = new Point(310, 71);
        musteriAdres.MaxLength = 255;
        musteriAdres.Name = "musteriAdres";
        musteriAdres.Size = new Size(132, 23);
        musteriAdres.TabIndex = 8;
        // 
        // musteriSoyad
        // 
        musteriSoyad.Location = new Point(93, 96);
        musteriSoyad.MaxLength = 50;
        musteriSoyad.Name = "musteriSoyad";
        musteriSoyad.Size = new Size(132, 23);
        musteriSoyad.TabIndex = 4;
        // 
        // musteriAd
        // 
        musteriAd.Location = new Point(93, 71);
        musteriAd.MaxLength = 50;
        musteriAd.Name = "musteriAd";
        musteriAd.Size = new Size(132, 23);
        musteriAd.TabIndex = 3;
        // 
        // musteriUnvan
        // 
        musteriUnvan.Location = new Point(93, 45);
        musteriUnvan.MaxLength = 255;
        musteriUnvan.Name = "musteriUnvan";
        musteriUnvan.Size = new Size(132, 23);
        musteriUnvan.TabIndex = 2;
        // 
        // musteriVergiNo
        // 
        musteriVergiNo.Location = new Point(93, 19);
        musteriVergiNo.MaxLength = 11;
        musteriVergiNo.Name = "musteriVergiNo";
        musteriVergiNo.Size = new Size(132, 23);
        musteriVergiNo.TabIndex = 1;
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(istisnaKodu);
        groupBox3.Controls.Add(label41);
        groupBox3.Controls.Add(gonderimSekli);
        groupBox3.Controls.Add(label40);
        groupBox3.Controls.Add(label30);
        groupBox3.Controls.Add(faturaTipi);
        groupBox3.Controls.Add(faturaZamani);
        groupBox3.Controls.Add(senaryo);
        groupBox3.Controls.Add(label35);
        groupBox3.Controls.Add(faturaNo);
        groupBox3.Controls.Add(paraBirimi);
        groupBox3.Controls.Add(faturaTarihi);
        groupBox3.Controls.Add(dovizKuru);
        groupBox3.Controls.Add(label28);
        groupBox3.Controls.Add(label29);
        groupBox3.Controls.Add(label25);
        groupBox3.Controls.Add(label27);
        groupBox3.Controls.Add(label26);
        groupBox3.Controls.Add(ettn);
        groupBox3.Controls.Add(label24);
        groupBox3.Location = new Point(468, 2);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(270, 275);
        groupBox3.TabIndex = 3;
        groupBox3.TabStop = false;
        groupBox3.Text = "Fatura Bilgileri";
        // 
        // istisnaKodu
        // 
        istisnaKodu.DropDownStyle = ComboBoxStyle.DropDownList;
        istisnaKodu.FormattingEnabled = true;
        istisnaKodu.Location = new Point(117, 245);
        istisnaKodu.Name = "istisnaKodu";
        istisnaKodu.Size = new Size(132, 23);
        istisnaKodu.TabIndex = 9;
        // 
        // label41
        // 
        label41.AutoSize = true;
        label41.Location = new Point(6, 250);
        label41.Name = "label41";
        label41.Size = new Size(71, 15);
        label41.TabIndex = 36;
        label41.Text = "İstisna Kodu";
        // 
        // gonderimSekli
        // 
        gonderimSekli.DropDownStyle = ComboBoxStyle.DropDownList;
        gonderimSekli.FormattingEnabled = true;
        gonderimSekli.Items.AddRange(new object[] { "KAGIT", "ELEKTRONIK" });
        gonderimSekli.Location = new Point(117, 219);
        gonderimSekli.Name = "gonderimSekli";
        gonderimSekli.Size = new Size(132, 23);
        gonderimSekli.TabIndex = 8;
        // 
        // label40
        // 
        label40.AutoSize = true;
        label40.Location = new Point(6, 225);
        label40.Name = "label40";
        label40.Size = new Size(87, 15);
        label40.TabIndex = 34;
        label40.Text = "Gönderim Şekli";
        // 
        // label30
        // 
        label30.AutoSize = true;
        label30.Location = new Point(6, 75);
        label30.Name = "label30";
        label30.Size = new Size(59, 15);
        label30.TabIndex = 32;
        label30.Text = "FaturaTipi";
        // 
        // faturaTipi
        // 
        faturaTipi.DropDownStyle = ComboBoxStyle.DropDownList;
        faturaTipi.FormattingEnabled = true;
        faturaTipi.Items.AddRange(new object[] { "SATIS", "IADE", "ISTISNA" });
        faturaTipi.Location = new Point(117, 69);
        faturaTipi.Name = "faturaTipi";
        faturaTipi.Size = new Size(132, 23);
        faturaTipi.TabIndex = 2;
        faturaTipi.SelectedIndexChanged += FaturaTipi_SelectedIndexChanged;
        // 
        // faturaZamani
        // 
        faturaZamani.CustomFormat = "";
        faturaZamani.Format = DateTimePickerFormat.Time;
        faturaZamani.Location = new Point(117, 143);
        faturaZamani.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
        faturaZamani.Name = "faturaZamani";
        faturaZamani.Size = new Size(132, 23);
        faturaZamani.TabIndex = 5;
        // 
        // senaryo
        // 
        senaryo.DropDownStyle = ComboBoxStyle.DropDownList;
        senaryo.FormattingEnabled = true;
        senaryo.Items.AddRange(new object[] { "EARSIVFATURA", "TEMELFATURA", "TICARIFATURA" });
        senaryo.Location = new Point(117, 44);
        senaryo.Name = "senaryo";
        senaryo.Size = new Size(132, 23);
        senaryo.TabIndex = 1;
        senaryo.SelectedIndexChanged += Senaryo_SelectedIndexChanged;
        // 
        // label35
        // 
        label35.AutoSize = true;
        label35.Location = new Point(6, 49);
        label35.Name = "label35";
        label35.Size = new Size(49, 15);
        label35.TabIndex = 28;
        label35.Text = "Senaryo";
        // 
        // faturaNo
        // 
        faturaNo.Location = new Point(117, 94);
        faturaNo.MaxLength = 16;
        faturaNo.Name = "faturaNo";
        faturaNo.Size = new Size(132, 23);
        faturaNo.TabIndex = 3;
        // 
        // paraBirimi
        // 
        paraBirimi.DropDownStyle = ComboBoxStyle.DropDownList;
        paraBirimi.FormattingEnabled = true;
        paraBirimi.Location = new Point(117, 168);
        paraBirimi.Name = "paraBirimi";
        paraBirimi.Size = new Size(132, 23);
        paraBirimi.TabIndex = 6;
        paraBirimi.SelectedIndexChanged += ParaBirimi_SelectedIndexChanged;
        // 
        // faturaTarihi
        // 
        faturaTarihi.CustomFormat = "yyyy-MM-dd";
        faturaTarihi.Format = DateTimePickerFormat.Custom;
        faturaTarihi.Location = new Point(117, 119);
        faturaTarihi.MinDate = new DateTime(2005, 1, 1, 0, 0, 0, 0);
        faturaTarihi.Name = "faturaTarihi";
        faturaTarihi.Size = new Size(132, 23);
        faturaTarihi.TabIndex = 4;
        // 
        // dovizKuru
        // 
        dovizKuru.Location = new Point(117, 193);
        dovizKuru.MaxLength = 20;
        dovizKuru.Name = "dovizKuru";
        dovizKuru.Size = new Size(132, 23);
        dovizKuru.TabIndex = 7;
        dovizKuru.Text = "1";
        // 
        // label28
        // 
        label28.AutoSize = true;
        label28.Location = new Point(6, 199);
        label28.Name = "label28";
        label28.Size = new Size(64, 15);
        label28.TabIndex = 26;
        label28.Text = "Döviz Kuru";
        // 
        // label29
        // 
        label29.AutoSize = true;
        label29.Location = new Point(6, 174);
        label29.Name = "label29";
        label29.Size = new Size(64, 15);
        label29.TabIndex = 25;
        label29.Text = "Para Birimi";
        // 
        // label25
        // 
        label25.AutoSize = true;
        label25.Location = new Point(6, 150);
        label25.Name = "label25";
        label25.Size = new Size(83, 15);
        label25.TabIndex = 24;
        label25.Text = "Fatura Zamanı";
        // 
        // label27
        // 
        label27.AutoSize = true;
        label27.Location = new Point(6, 125);
        label27.Name = "label27";
        label27.Size = new Size(71, 15);
        label27.TabIndex = 23;
        label27.Text = "Fatura Tarihi";
        // 
        // label26
        // 
        label26.AutoSize = true;
        label26.Location = new Point(6, 100);
        label26.Name = "label26";
        label26.Size = new Size(94, 15);
        label26.TabIndex = 21;
        label26.Text = "Fatura Numarası";
        // 
        // ettn
        // 
        ettn.AutoSize = true;
        ettn.Location = new Point(43, 23);
        ettn.Name = "ettn";
        ettn.Size = new Size(0, 15);
        ettn.TabIndex = 20;
        // 
        // label24
        // 
        label24.AutoSize = true;
        label24.Location = new Point(6, 23);
        label24.Name = "label24";
        label24.Size = new Size(34, 15);
        label24.TabIndex = 19;
        label24.Text = "ETTN";
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(siparisTarihi);
        groupBox4.Controls.Add(siparisNumarasi);
        groupBox4.Controls.Add(label31);
        groupBox4.Controls.Add(label33);
        groupBox4.Location = new Point(744, 2);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new Size(250, 70);
        groupBox4.TabIndex = 4;
        groupBox4.TabStop = false;
        groupBox4.Text = "Sipariş Bilgileri";
        // 
        // siparisTarihi
        // 
        siparisTarihi.Location = new Point(108, 42);
        siparisTarihi.Name = "siparisTarihi";
        siparisTarihi.Size = new Size(132, 23);
        siparisTarihi.TabIndex = 2;
        // 
        // siparisNumarasi
        // 
        siparisNumarasi.Location = new Point(108, 17);
        siparisNumarasi.MaxLength = 16;
        siparisNumarasi.Name = "siparisNumarasi";
        siparisNumarasi.Size = new Size(132, 23);
        siparisNumarasi.TabIndex = 1;
        // 
        // label31
        // 
        label31.AutoSize = true;
        label31.Location = new Point(7, 46);
        label31.Name = "label31";
        label31.Size = new Size(72, 15);
        label31.TabIndex = 24;
        label31.Text = "Sipariş Tarihi";
        // 
        // label33
        // 
        label33.AutoSize = true;
        label33.Location = new Point(7, 21);
        label33.Name = "label33";
        label33.Size = new Size(95, 15);
        label33.TabIndex = 22;
        label33.Text = "Sipariş Numarası";
        // 
        // groupBox8
        // 
        groupBox8.Controls.Add(label1);
        groupBox8.Controls.Add(odenecekTutar);
        groupBox8.Controls.Add(label2);
        groupBox8.Controls.Add(toplamIskonto);
        groupBox8.Controls.Add(label5);
        groupBox8.Controls.Add(malHizmetToplamTutari);
        groupBox8.Controls.Add(vergilerDahilToplamTutar);
        groupBox8.Controls.Add(hesaplananKdv);
        groupBox8.Controls.Add(label3);
        groupBox8.Controls.Add(label4);
        groupBox8.Location = new Point(724, 584);
        groupBox8.Name = "groupBox8";
        groupBox8.Size = new Size(270, 110);
        groupBox8.TabIndex = 12;
        groupBox8.TabStop = false;
        groupBox8.Text = "Toplamlar";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(7, 19);
        label1.Name = "label1";
        label1.Size = new Size(145, 15);
        label1.TabIndex = 0;
        label1.Text = "Mal/Hizmet Toplam Tutarı";
        // 
        // odenecekTutar
        // 
        odenecekTutar.AutoSize = true;
        odenecekTutar.Location = new Point(157, 91);
        odenecekTutar.Name = "odenecekTutar";
        odenecekTutar.Size = new Size(13, 15);
        odenecekTutar.TabIndex = 9;
        odenecekTutar.Text = "0";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(7, 37);
        label2.Name = "label2";
        label2.Size = new Size(88, 15);
        label2.TabIndex = 2;
        label2.Text = "Toplam İskonto";
        // 
        // toplamIskonto
        // 
        toplamIskonto.AutoSize = true;
        toplamIskonto.Location = new Point(157, 38);
        toplamIskonto.Name = "toplamIskonto";
        toplamIskonto.Size = new Size(13, 15);
        toplamIskonto.TabIndex = 3;
        toplamIskonto.Text = "0";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(5, 92);
        label5.Name = "label5";
        label5.Size = new Size(90, 15);
        label5.TabIndex = 8;
        label5.Text = "Ödenecek Tutar";
        // 
        // malHizmetToplamTutari
        // 
        malHizmetToplamTutari.AutoSize = true;
        malHizmetToplamTutari.Location = new Point(157, 19);
        malHizmetToplamTutari.Name = "malHizmetToplamTutari";
        malHizmetToplamTutari.Size = new Size(13, 15);
        malHizmetToplamTutari.TabIndex = 1;
        malHizmetToplamTutari.Text = "0";
        // 
        // vergilerDahilToplamTutar
        // 
        vergilerDahilToplamTutar.AutoSize = true;
        vergilerDahilToplamTutar.Location = new Point(157, 75);
        vergilerDahilToplamTutar.Name = "vergilerDahilToplamTutar";
        vergilerDahilToplamTutar.Size = new Size(13, 15);
        vergilerDahilToplamTutar.TabIndex = 7;
        vergilerDahilToplamTutar.Text = "0";
        // 
        // hesaplananKdv
        // 
        hesaplananKdv.AutoSize = true;
        hesaplananKdv.Location = new Point(157, 57);
        hesaplananKdv.Name = "hesaplananKdv";
        hesaplananKdv.Size = new Size(13, 15);
        hesaplananKdv.TabIndex = 5;
        hesaplananKdv.Text = "0";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(7, 55);
        label3.Name = "label3";
        label3.Size = new Size(94, 15);
        label3.TabIndex = 4;
        label3.Text = "Hesaplanan KDV";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(5, 74);
        label4.Name = "label4";
        label4.Size = new Size(148, 15);
        label4.TabIndex = 6;
        label4.Text = "Vergiler Dahil Toplam Tutar";
        // 
        // groupBox5
        // 
        groupBox5.Controls.Add(irsaliyeTarihi);
        groupBox5.Controls.Add(irsaliyeNumarasi);
        groupBox5.Controls.Add(label32);
        groupBox5.Controls.Add(label34);
        groupBox5.Location = new Point(743, 77);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new Size(250, 70);
        groupBox5.TabIndex = 5;
        groupBox5.TabStop = false;
        groupBox5.Text = "İrsaliye Bilgileri";
        // 
        // irsaliyeTarihi
        // 
        irsaliyeTarihi.Location = new Point(109, 42);
        irsaliyeTarihi.Name = "irsaliyeTarihi";
        irsaliyeTarihi.Size = new Size(132, 23);
        irsaliyeTarihi.TabIndex = 2;
        // 
        // irsaliyeNumarasi
        // 
        irsaliyeNumarasi.Location = new Point(109, 17);
        irsaliyeNumarasi.MaxLength = 16;
        irsaliyeNumarasi.Name = "irsaliyeNumarasi";
        irsaliyeNumarasi.Size = new Size(132, 23);
        irsaliyeNumarasi.TabIndex = 1;
        // 
        // label32
        // 
        label32.AutoSize = true;
        label32.Location = new Point(6, 47);
        label32.Name = "label32";
        label32.Size = new Size(74, 15);
        label32.TabIndex = 26;
        label32.Text = "İrsaliye Tarihi";
        // 
        // label34
        // 
        label34.AutoSize = true;
        label34.Location = new Point(6, 23);
        label34.Name = "label34";
        label34.Size = new Size(97, 15);
        label34.TabIndex = 25;
        label34.Text = "İrsaliye Numarası";
        // 
        // groupBox7
        // 
        groupBox7.Controls.Add(not);
        groupBox7.Location = new Point(12, 584);
        groupBox7.Name = "groupBox7";
        groupBox7.Size = new Size(710, 110);
        groupBox7.TabIndex = 11;
        groupBox7.TabStop = false;
        groupBox7.Text = "Notlar";
        // 
        // not
        // 
        not.Location = new Point(5, 15);
        not.Multiline = true;
        not.Name = "not";
        not.Size = new Size(700, 90);
        not.TabIndex = 1;
        // 
        // satir
        // 
        satir.AllowUserToOrderColumns = true;
        satir.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        satir.Columns.AddRange(new DataGridViewColumn[] { siraNo, malHizmet, miktar, olcu, birimFiyat, kdvOrani, kdvTutari, iskontoOrani, iskontoTutari, malHizmetTutari });
        satir.Location = new Point(12, 308);
        satir.Name = "satir";
        satir.RowHeadersWidth = 50;
        satir.RowTemplate.Height = 24;
        satir.Size = new Size(982, 270);
        satir.TabIndex = 10;
        satir.CellEndEdit += Satir_CellEndEdit;
        // 
        // siraNo
        // 
        siraNo.HeaderText = "Sıra No";
        siraNo.MaxInputLength = 3;
        siraNo.Name = "siraNo";
        siraNo.ReadOnly = true;
        siraNo.Resizable = DataGridViewTriState.True;
        siraNo.Width = 30;
        // 
        // malHizmet
        // 
        malHizmet.HeaderText = "Mal/Hizmet";
        malHizmet.MaxInputLength = 255;
        malHizmet.Name = "malHizmet";
        malHizmet.Width = 200;
        // 
        // miktar
        // 
        miktar.HeaderText = "Miktar";
        miktar.MaxInputLength = 20;
        miktar.Name = "miktar";
        // 
        // olcu
        // 
        olcu.HeaderText = "Birim";
        olcu.Name = "olcu";
        // 
        // birimFiyat
        // 
        birimFiyat.HeaderText = "Birim Fiyat";
        birimFiyat.MaxInputLength = 20;
        birimFiyat.Name = "birimFiyat";
        // 
        // kdvOrani
        // 
        kdvOrani.HeaderText = "KDV Oranı";
        kdvOrani.MaxInputLength = 3;
        kdvOrani.Name = "kdvOrani";
        kdvOrani.Width = 50;
        // 
        // kdvTutari
        // 
        kdvTutari.HeaderText = "KDV Tutarı";
        kdvTutari.MaxInputLength = 20;
        kdvTutari.Name = "kdvTutari";
        kdvTutari.ReadOnly = true;
        // 
        // iskontoOrani
        // 
        iskontoOrani.HeaderText = "İskonto Oranı";
        iskontoOrani.MaxInputLength = 3;
        iskontoOrani.Name = "iskontoOrani";
        iskontoOrani.Width = 50;
        // 
        // iskontoTutari
        // 
        iskontoTutari.HeaderText = "İskonto Tutarı";
        iskontoTutari.MaxInputLength = 20;
        iskontoTutari.Name = "iskontoTutari";
        // 
        // malHizmetTutari
        // 
        malHizmetTutari.HeaderText = "Mal/Hizmet Tutarı";
        malHizmetTutari.MaxInputLength = 20;
        malHizmetTutari.Name = "malHizmetTutari";
        malHizmetTutari.ReadOnly = true;
        // 
        // gonder
        // 
        gonder.Location = new Point(166, 16);
        gonder.Name = "gonder";
        gonder.Size = new Size(75, 25);
        gonder.TabIndex = 9;
        gonder.Text = "Gönder";
        gonder.UseVisualStyleBackColor = true;
        gonder.Click += Gonder_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(saticiSehir);
        groupBox1.Controls.Add(saticiIlce);
        groupBox1.Controls.Add(label10);
        groupBox1.Controls.Add(label11);
        groupBox1.Controls.Add(label12);
        groupBox1.Controls.Add(label13);
        groupBox1.Controls.Add(label17);
        groupBox1.Controls.Add(label18);
        groupBox1.Controls.Add(label20);
        groupBox1.Controls.Add(label22);
        groupBox1.Controls.Add(label36);
        groupBox1.Controls.Add(label37);
        groupBox1.Controls.Add(saticiVergiDairesi);
        groupBox1.Controls.Add(saticiEposta);
        groupBox1.Controls.Add(saticiTelefon);
        groupBox1.Controls.Add(saticiAdres);
        groupBox1.Controls.Add(saticiSoyad);
        groupBox1.Controls.Add(saticiAd);
        groupBox1.Controls.Add(saticiUnvan);
        groupBox1.Controls.Add(saticiVergiNo);
        groupBox1.Location = new Point(12, 2);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(450, 150);
        groupBox1.TabIndex = 1;
        groupBox1.TabStop = false;
        groupBox1.Text = "Satıcı Bilgileri";
        // 
        // saticiSehir
        // 
        saticiSehir.FormattingEnabled = true;
        saticiSehir.Location = new Point(310, 96);
        saticiSehir.Name = "saticiSehir";
        saticiSehir.Size = new Size(132, 23);
        saticiSehir.TabIndex = 9;
        saticiSehir.SelectedIndexChanged += SaticiSehir_SelectedIndexChanged;
        // 
        // saticiIlce
        // 
        saticiIlce.FormattingEnabled = true;
        saticiIlce.Location = new Point(310, 121);
        saticiIlce.Name = "saticiIlce";
        saticiIlce.Size = new Size(132, 23);
        saticiIlce.TabIndex = 10;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(3, 124);
        label10.Name = "label10";
        label10.Size = new Size(71, 15);
        label10.TabIndex = 34;
        label10.Text = "Vergi Dairesi";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(238, 50);
        label11.Name = "label11";
        label11.Size = new Size(47, 15);
        label11.TabIndex = 30;
        label11.Text = "e-Posta";
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Location = new Point(238, 26);
        label12.Name = "label12";
        label12.Size = new Size(45, 15);
        label12.TabIndex = 26;
        label12.Text = "Telefon";
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new Point(238, 100);
        label13.Name = "label13";
        label13.Size = new Size(33, 15);
        label13.TabIndex = 20;
        label13.Text = "Şehir";
        // 
        // label17
        // 
        label17.AutoSize = true;
        label17.Location = new Point(238, 123);
        label17.Name = "label17";
        label17.Size = new Size(25, 15);
        label17.TabIndex = 18;
        label17.Text = "İlçe";
        // 
        // label18
        // 
        label18.AutoSize = true;
        label18.Location = new Point(240, 77);
        label18.Name = "label18";
        label18.Size = new Size(37, 15);
        label18.TabIndex = 8;
        label18.Text = "Adres";
        // 
        // label20
        // 
        label20.AutoSize = true;
        label20.Location = new Point(4, 99);
        label20.Name = "label20";
        label20.Size = new Size(39, 15);
        label20.TabIndex = 6;
        label20.Text = "Soyad";
        // 
        // label22
        // 
        label22.AutoSize = true;
        label22.Location = new Point(5, 73);
        label22.Name = "label22";
        label22.Size = new Size(22, 15);
        label22.TabIndex = 4;
        label22.Text = "Ad";
        // 
        // label36
        // 
        label36.AutoSize = true;
        label36.Location = new Point(5, 49);
        label36.Name = "label36";
        label36.Size = new Size(41, 15);
        label36.TabIndex = 2;
        label36.Text = "Ünvan";
        // 
        // label37
        // 
        label37.AutoSize = true;
        label37.Location = new Point(5, 25);
        label37.Name = "label37";
        label37.Size = new Size(87, 15);
        label37.TabIndex = 0;
        label37.Text = "Vergi Numarası";
        // 
        // saticiVergiDairesi
        // 
        saticiVergiDairesi.Location = new Point(93, 121);
        saticiVergiDairesi.MaxLength = 50;
        saticiVergiDairesi.Name = "saticiVergiDairesi";
        saticiVergiDairesi.Size = new Size(132, 23);
        saticiVergiDairesi.TabIndex = 5;
        // 
        // saticiEposta
        // 
        saticiEposta.Location = new Point(310, 45);
        saticiEposta.MaxLength = 50;
        saticiEposta.Name = "saticiEposta";
        saticiEposta.Size = new Size(132, 23);
        saticiEposta.TabIndex = 7;
        // 
        // saticiTelefon
        // 
        saticiTelefon.Location = new Point(310, 19);
        saticiTelefon.MaxLength = 20;
        saticiTelefon.Name = "saticiTelefon";
        saticiTelefon.Size = new Size(132, 23);
        saticiTelefon.TabIndex = 6;
        // 
        // saticiAdres
        // 
        saticiAdres.Location = new Point(310, 71);
        saticiAdres.MaxLength = 255;
        saticiAdres.Name = "saticiAdres";
        saticiAdres.Size = new Size(132, 23);
        saticiAdres.TabIndex = 8;
        // 
        // saticiSoyad
        // 
        saticiSoyad.Location = new Point(93, 96);
        saticiSoyad.MaxLength = 50;
        saticiSoyad.Name = "saticiSoyad";
        saticiSoyad.Size = new Size(132, 23);
        saticiSoyad.TabIndex = 4;
        // 
        // saticiAd
        // 
        saticiAd.Location = new Point(93, 71);
        saticiAd.MaxLength = 50;
        saticiAd.Name = "saticiAd";
        saticiAd.Size = new Size(132, 23);
        saticiAd.TabIndex = 3;
        // 
        // saticiUnvan
        // 
        saticiUnvan.Location = new Point(93, 45);
        saticiUnvan.MaxLength = 255;
        saticiUnvan.Name = "saticiUnvan";
        saticiUnvan.Size = new Size(132, 23);
        saticiUnvan.TabIndex = 2;
        // 
        // saticiVergiNo
        // 
        saticiVergiNo.Location = new Point(93, 19);
        saticiVergiNo.MaxLength = 11;
        saticiVergiNo.Name = "saticiVergiNo";
        saticiVergiNo.Size = new Size(132, 23);
        saticiVergiNo.TabIndex = 1;
        // 
        // groupBox6
        // 
        groupBox6.Controls.Add(iadeFaturaTarihi);
        groupBox6.Controls.Add(iadeFaturaNo);
        groupBox6.Controls.Add(label38);
        groupBox6.Controls.Add(label39);
        groupBox6.Location = new Point(744, 152);
        groupBox6.Name = "groupBox6";
        groupBox6.Size = new Size(250, 70);
        groupBox6.TabIndex = 6;
        groupBox6.TabStop = false;
        groupBox6.Text = "İade Fatura Bilgileri";
        // 
        // iadeFaturaTarihi
        // 
        iadeFaturaTarihi.Location = new Point(108, 41);
        iadeFaturaTarihi.Name = "iadeFaturaTarihi";
        iadeFaturaTarihi.Size = new Size(132, 23);
        iadeFaturaTarihi.TabIndex = 2;
        // 
        // iadeFaturaNo
        // 
        iadeFaturaNo.Location = new Point(108, 16);
        iadeFaturaNo.MaxLength = 16;
        iadeFaturaNo.Name = "iadeFaturaNo";
        iadeFaturaNo.Size = new Size(132, 23);
        iadeFaturaNo.TabIndex = 1;
        // 
        // label38
        // 
        label38.AutoSize = true;
        label38.Location = new Point(6, 48);
        label38.Name = "label38";
        label38.Size = new Size(71, 15);
        label38.TabIndex = 26;
        label38.Text = "Fatura Tarihi";
        // 
        // label39
        // 
        label39.AutoSize = true;
        label39.Location = new Point(6, 24);
        label39.Name = "label39";
        label39.Size = new Size(94, 15);
        label39.TabIndex = 25;
        label39.Text = "Fatura Numarası";
        // 
        // kaydet
        // 
        kaydet.Location = new Point(7, 44);
        kaydet.Name = "kaydet";
        kaydet.Size = new Size(75, 25);
        kaydet.TabIndex = 7;
        kaydet.Text = "Kaydet";
        kaydet.UseVisualStyleBackColor = true;
        kaydet.Click += Kaydet_Click;
        // 
        // goruntule
        // 
        goruntule.Location = new Point(86, 16);
        goruntule.Name = "goruntule";
        goruntule.Size = new Size(75, 25);
        goruntule.TabIndex = 8;
        goruntule.Text = "Görüntüle";
        goruntule.UseVisualStyleBackColor = true;
        goruntule.Click += Goruntule_Click;
        // 
        // ac
        // 
        ac.Location = new Point(7, 16);
        ac.Name = "ac";
        ac.Size = new Size(75, 25);
        ac.TabIndex = 13;
        ac.Text = "Aç";
        ac.UseVisualStyleBackColor = true;
        ac.Click += Ac_Click;
        // 
        // temizle
        // 
        temizle.Location = new Point(166, 44);
        temizle.Name = "temizle";
        temizle.Size = new Size(75, 25);
        temizle.TabIndex = 14;
        temizle.Text = "Temizle";
        temizle.UseVisualStyleBackColor = true;
        temizle.Click += Temizle_Click;
        // 
        // sablonSec
        // 
        sablonSec.Location = new Point(86, 44);
        sablonSec.Name = "sablonSec";
        sablonSec.Size = new Size(75, 25);
        sablonSec.TabIndex = 15;
        sablonSec.Text = "Şablon Seç";
        sablonSec.UseVisualStyleBackColor = true;
        sablonSec.Click += SablonSec_Click;
        // 
        // groupBox9
        // 
        groupBox9.Controls.Add(sablonSec);
        groupBox9.Controls.Add(temizle);
        groupBox9.Controls.Add(ac);
        groupBox9.Controls.Add(kaydet);
        groupBox9.Controls.Add(goruntule);
        groupBox9.Controls.Add(gonder);
        groupBox9.Location = new Point(743, 229);
        groupBox9.Name = "groupBox9";
        groupBox9.Size = new Size(250, 75);
        groupBox9.TabIndex = 27;
        groupBox9.TabStop = false;
        groupBox9.Text = "İşlemler";
        // 
        // EFaturaOlustur
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1008, 701);
        Controls.Add(groupBox9);
        Controls.Add(groupBox6);
        Controls.Add(groupBox1);
        Controls.Add(groupBox5);
        Controls.Add(groupBox4);
        Controls.Add(groupBox3);
        Controls.Add(groupBox7);
        Controls.Add(groupBox8);
        Controls.Add(groupBox2);
        Controls.Add(satir);
        Name = "EFaturaOlustur";
        Text = "e-Fatura Oluştur";
        Load += Fatura_Load;
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        groupBox8.ResumeLayout(false);
        groupBox8.PerformLayout();
        groupBox5.ResumeLayout(false);
        groupBox5.PerformLayout();
        groupBox7.ResumeLayout(false);
        groupBox7.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)satir).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox6.ResumeLayout(false);
        groupBox6.PerformLayout();
        groupBox9.ResumeLayout(false);
        ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.GroupBox groupBox8;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.DataGridView satir;
    private System.Windows.Forms.Label odenecekTutar;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label vergilerDahilToplamTutar;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label hesaplananKdv;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label toplamIskonto;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label malHizmetToplamTutari;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label23;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox musteriVergiDairesi;
    private System.Windows.Forms.TextBox musteriEposta;
    private System.Windows.Forms.TextBox musteriTelefon;
    private System.Windows.Forms.TextBox musteriAdres;
    private System.Windows.Forms.TextBox musteriSoyad;
    private System.Windows.Forms.TextBox musteriAd;
    private System.Windows.Forms.TextBox musteriUnvan;
    private System.Windows.Forms.TextBox musteriVergiNo;
    private System.Windows.Forms.TextBox not;
    private System.Windows.Forms.Label label28;
    private System.Windows.Forms.Label label29;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label27;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label ettn;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.TextBox siparisNumarasi;
    private System.Windows.Forms.Label label31;
    private System.Windows.Forms.Label label33;
    private System.Windows.Forms.TextBox irsaliyeNumarasi;
    private System.Windows.Forms.Label label32;
    private System.Windows.Forms.Label label34;
    private System.Windows.Forms.ComboBox paraBirimi;
    private System.Windows.Forms.DateTimePicker faturaTarihi;
    private System.Windows.Forms.TextBox dovizKuru;
    private System.Windows.Forms.DateTimePicker siparisTarihi;
    private System.Windows.Forms.DateTimePicker irsaliyeTarihi;
    private System.Windows.Forms.TextBox faturaNo;
    private System.Windows.Forms.Button gonder;
    private System.Windows.Forms.ComboBox senaryo;
    private System.Windows.Forms.Label label35;
    private System.Windows.Forms.DateTimePicker faturaZamani;
    private GroupBox groupBox1;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label17;
    private Label label18;
    private Label label20;
    private Label label22;
    private Label label36;
    private Label label37;
    private TextBox saticiVergiDairesi;
    private TextBox saticiEposta;
    private TextBox saticiTelefon;
    private TextBox saticiAdres;
    private TextBox saticiSoyad;
    private TextBox saticiAd;
    private TextBox saticiUnvan;
    private TextBox saticiVergiNo;
    private Label label30;
    private ComboBox faturaTipi;
    private GroupBox groupBox6;
    private DateTimePicker iadeFaturaTarihi;
    private TextBox iadeFaturaNo;
    private Label label38;
    private Label label39;
    private ComboBox gonderimSekli;
    private Label label40;
    private Button kaydet;
    private Button goruntule;
    private Label label41;
    private ComboBox saticiSehir;
    private ComboBox saticiIlce;
    private ComboBox musteriIlce;
    private ComboBox musteriSehir;
    private DataGridViewTextBoxColumn siraNo;
    private DataGridViewTextBoxColumn malHizmet;
    private DataGridViewTextBoxColumn miktar;
    private DataGridViewComboBoxColumn olcu;
    private DataGridViewTextBoxColumn birimFiyat;
    private DataGridViewTextBoxColumn kdvOrani;
    private DataGridViewTextBoxColumn kdvTutari;
    private DataGridViewTextBoxColumn iskontoOrani;
    private DataGridViewTextBoxColumn iskontoTutari;
    private DataGridViewTextBoxColumn malHizmetTutari;
    private Button ac;
    private Button temizle;
    private Button sablonSec;
    private GroupBox groupBox9;
    private ComboBox istisnaKodu;
}