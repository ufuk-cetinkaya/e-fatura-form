using System.Configuration;
using System.Diagnostics;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace EFaturaForm;

public partial class EFaturaOlustur : Form
{
    private readonly DocumentReferenceType _template;
    private readonly List<Sehir> _saticiSehirler;
    private readonly List<Sehir> _musteriSehirler;
    private readonly List<Ilce> _saticiIlceler;
    private readonly List<Ilce> _musteriIlceler;

    public EFaturaOlustur()
    {
        InitializeComponent();

        _template = Template();

        using FileStream fs1 = File.OpenRead("resources/sehirler.json");
        using FileStream fs2 = File.OpenRead("resources/Ilceler.json");

        _saticiSehirler = JsonSerializer.Deserialize<List<Sehir>>(fs1) ??
            throw new Exception("Þehirler Yüklenemedi");
        fs1.Position = 0;
        _musteriSehirler = JsonSerializer.Deserialize<List<Sehir>>(fs1) ??
            throw new Exception("Þehirler Yüklenemedi");

        _saticiIlceler = JsonSerializer.Deserialize<List<Ilce>>(fs2) ??
            throw new Exception("Ýlçeler Yüklenemedi");
        fs2.Position = 0;
        _musteriIlceler = JsonSerializer.Deserialize<List<Ilce>>(fs2) ??
            throw new Exception("Ýlçeler Yüklenemedi");
    }

    private void Fatura_Load(object sender, EventArgs e)
    {
        ettn.Text = Guid.NewGuid().ToString();
        senaryo.SelectedIndex = 0;
        faturaTipi.SelectedIndex = 0;
        gonderimSekli.SelectedIndex = 0;
        FillCurrencies(paraBirimi);
        paraBirimi.SelectedIndex = 0;
        FillUnitCodes(olcu);
        FillExemptions(istisnaKodu);

        saticiSehir.DataSource = _saticiSehirler;
        saticiSehir.ValueMember = "SehirId";
        saticiSehir.DisplayMember = "SehirAdi";
        saticiSehir.SelectedIndex = 33;

        musteriSehir.DataSource = _musteriSehirler;
        musteriSehir.ValueMember = "SehirId";
        musteriSehir.DisplayMember = "SehirAdi";
        musteriSehir.SelectedIndex = 33;
    }

    private async void Gonder_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult result = MessageBox.Show("Faturanýn gönderimini onaylýyor musunuz?", faturaNo.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                byte[] fatura = Save();
                await SendDocument(fatura);
                MessageBox.Show("Fatura baþarýyla gönderildi.", faturaNo.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ettn.Text = Guid.NewGuid().ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.CreateDirectory("log");
            File.AppendAllText("log/error.log", ex.StackTrace);
        }
    }

    private void Goruntule_Click(object sender, EventArgs e)
    {
        try
        {
            Preview();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.CreateDirectory("log");
            File.AppendAllText("log/error.log", ex.StackTrace);
        }
    }

    private void Kaydet_Click(object sender, EventArgs e)
    {
        try
        {
            Save();
            MessageBox.Show("Fatura kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.CreateDirectory("log");
            File.AppendAllText("log/error.log", ex.StackTrace);
        }
    }

    private InvoiceType CreateInvoice()
    {
        InvoiceType inv = new();
        inv.UBLExtensions = UBLExtension();
        inv.UBLVersionID = new UBLVersionIDType { Value = "2.1" };
        inv.CustomizationID = new CustomizationIDType { Value = "TR1.2" };
        inv.CopyIndicator = new CopyIndicatorType { Value = false };
        inv.ProfileID = new ProfileIDType { Value = senaryo.Text };
        inv.InvoiceTypeCode = new InvoiceTypeCodeType { Value = faturaTipi.Text };
        inv.ID = InvoiceId();
        inv.UUID = new UUIDType { Value = ettn.Text };
        inv.IssueDate = new IssueDateType { Value = faturaTarihi.Value };
        inv.IssueTime = new IssueTimeType { Value = faturaTarihi.Value };
        inv.DespatchDocumentReference = [Despatch()];
        inv.OrderReference = Order();
        inv.BillingReference = [Iade()];
        inv.AdditionalDocumentReference = [_template, SendingType()];
        inv.DocumentCurrencyCode = new DocumentCurrencyCodeType { Value = paraBirimi.SelectedValue?.ToString() };
        inv.PricingExchangeRate = ExchangeRate();
        inv.LineCountNumeric = new LineCountNumericType { Value = satir.RowCount - 1 };
        inv.Note = Notes();
        inv.Signature = [ new SignatureType { ID = new IDType { schemeID = "VKN_TCKN", Value = saticiVergiNo.Text }, SignatoryParty = Supplier(),
            DigitalSignatureAttachment = new AttachmentType { ExternalReference = new ExternalReferenceType { URI = new URIType { Value = $"#Signature_{ettn.Text}" } } } } ];
        inv.AccountingSupplierParty = new SupplierPartyType { Party = Supplier() };
        inv.AccountingCustomerParty = new CustomerPartyType { Party = Customer() };
        inv.TaxTotal = TaxTotal();
        inv.LegalMonetaryTotal = MonetaryTotal();
        inv.InvoiceLine = InvoiceLines();
        return inv;
    }

    private static UBLExtensionType[] UBLExtension()
    {
        return
        [
            new UBLExtensionType
            {
                ExtensionContent = new XmlDocument().CreateElement("n4", "auto-generated_for_wildcard", "http://www.altova.com/samplexml/other-namespace")
            }
        ];
    }

    private IDType InvoiceId()
    {
        if (faturaNo.Text.Trim().Length < 16)
            throw new Exception("Fatura numarasý 16 hane olmalýdýr.");
        else return new IDType { Value = faturaNo.Text };
    }

    private DocumentReferenceType? Despatch()
    {
        DocumentReferenceType? despatch = null;
        if (irsaliyeNumarasi.Text.Trim() != "")
        {
            despatch = new DocumentReferenceType
            {
                ID = new IDType { Value = irsaliyeNumarasi.Text },
                IssueDate = new IssueDateType { Value = irsaliyeTarihi.Value }
            };
        }
        return despatch;
    }

    private OrderReferenceType? Order()
    {
        OrderReferenceType? order = null;
        if (siparisNumarasi.Text.Trim() != "")
        {
            order = new OrderReferenceType
            {
                ID = new IDType { Value = siparisNumarasi.Text },
                IssueDate = new IssueDateType { Value = siparisTarihi.Value }
            };
        }
        return order;
    }

    private static DocumentReferenceType Template()
    {
        DocumentReferenceType docRef = new()
        {
            ID = new IDType { Value = Guid.NewGuid().ToString() },
            IssueDate = new IssueDateType { Value = DateTime.Now },
            DocumentType = new DocumentTypeType { Value = "XSLT" },
            Attachment = new AttachmentType
            {
                EmbeddedDocumentBinaryObject = new()
                {
                    filename = "general.xslt",
                    mimeCode = "application/xml",
                    encodingCode = "Base64",
                    characterSetCode = "UTF-8",
                    Value = File.ReadAllBytes("xslt/general.xslt")
                }
            }
        };
        return docRef;
    }

    private BillingReferenceType? Iade()
    {
        BillingReferenceType? iade = null;
        if (faturaTipi.Text == "IADE")
        {
            if (iadeFaturaNo.Text.Trim().Length < 16)
                throw new Exception("Fatura tipi iade iken 16 hane fatura numarasý belirtilmelidir.");
            else if (senaryo.Text != "TEMELFATURA")
                throw new Exception("Fatura tipi iade iken senaryo TEMELFATURA olmalýdýr.");
            else
                iade = new()
                {
                    InvoiceDocumentReference = new()
                    {
                        ID = new IDType { Value = iadeFaturaNo.Text },
                        IssueDate = new IssueDateType { Value = iadeFaturaTarihi.Value },
                        DocumentTypeCode = new DocumentTypeCodeType { Value = "IADE" },
                        DocumentType = new DocumentTypeType { Value = "Ýade Edilen Fatura" }
                    }
                };
        }
        return iade;
    }

    private DocumentReferenceType? SendingType()
    {
        DocumentReferenceType? sendingType = null;
        if (senaryo.Text == "EARSIVFATURA")
        {
            if (gonderimSekli.Text == "ELEKTRONIK" && musteriEposta.Text.Trim() == "")
                throw new Exception("Gönderim þekli ELEKTRONIK iken alýcýnýn e-posta adresi belirtilmelidir.");
            else
                sendingType = new()
                {
                    ID = new IDType { Value = faturaNo.Text },
                    IssueDate = new IssueDateType { Value = faturaTarihi.Value },
                    DocumentTypeCode = new DocumentTypeCodeType { Value = "SendingType" },
                    DocumentType = new DocumentTypeType { Value = gonderimSekli.Text }
                };
        }
        return sendingType;
    }

    private ExchangeRateType? ExchangeRate()
    {
        ExchangeRateType? doviz = null;
        if (paraBirimi.SelectedValue?.ToString() != "TRY")
            doviz = new ExchangeRateType
            {
                SourceCurrencyCode = new SourceCurrencyCodeType { Value = paraBirimi.SelectedValue?.ToString() },
                TargetCurrencyCode = new TargetCurrencyCodeType { Value = "TRY" },
                CalculationRate = new CalculationRateType { Value = decimal.Parse(dovizKuru.Text) },
                Date = new DateType1 { Value = faturaTarihi.Value }
            };
        return doviz;
    }

    private NoteType[] Notes()
    {
        NoteType[] notes = new NoteType[not.Lines.Length];

        for (int i = 0; i < not.Lines.Length; i++)
        {
            notes[i] = new NoteType { Value = not.Lines[i] };
        }
        return notes;
    }

    private PartyType Supplier()
    {
        PartyType supplier = new()
        {
            PartyIdentification = [PartyId(saticiVergiNo.Text)],
            PartyName = PartyName(saticiVergiNo.Text, saticiUnvan.Text),
            PartyTaxScheme = TaxScheme(saticiVergiDairesi.Text),
            PostalAddress = Address(saticiAdres.Text, saticiIlce.Text, saticiSehir.Text),
            Contact = Contact(saticiEposta.Text, saticiTelefon.Text),
            Person = Person(saticiVergiNo.Text, saticiAd.Text, saticiSoyad.Text)
        };
        return supplier;
    }

    private static PartyTaxSchemeType TaxScheme(string vergiDairesi)
    {
        PartyTaxSchemeType vd;
        if (vergiDairesi.Trim() == "")
            throw new Exception("Vergi dairesi boþ olamaz.");
        else vd = new PartyTaxSchemeType { TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = vergiDairesi } } };
        return vd;
    }

    private PartyType Customer()
    {
        PartyType customer = new()
        {
            PartyIdentification = [PartyId(musteriVergiNo.Text)],
            PartyName = PartyName(musteriVergiNo.Text, musteriUnvan.Text),
            PartyTaxScheme = TaxScheme(musteriVergiDairesi.Text),
            PostalAddress = Address(musteriAdres.Text, musteriIlce.Text, musteriSehir.Text),
            Contact = Contact(musteriEposta.Text, musteriTelefon.Text),
            Person = Person(musteriVergiNo.Text, musteriAd.Text, musteriSoyad.Text)
        };
        return customer;
    }

    private static PartyIdentificationType PartyId(string vknTckn)
    {
        PartyIdentificationType id = new() { ID = new IDType() };
        if (vknTckn.Length == 10 && vknTckn.All(char.IsDigit))
            id.ID.schemeID = "VKN";
        else if (vknTckn.Length == 11 && vknTckn.All(char.IsDigit))
            id.ID.schemeID = "TCKN";
        else throw new Exception("10 hane vergi kimlik veya 11 hane TC kimlik numarasý girilmelidir.");
        id.ID.Value = vknTckn;
        return id;
    }

    private static PartyNameType? PartyName(string vknTckn, string unvan)
    {
        PartyNameType? company = null;
        if (vknTckn.Length == 10 && unvan.Trim() == "")
        {
            throw new Exception("Ünvan alaný zorunludur.");
        }
        if (unvan.Trim() != "")
        {
            company = new();
            company.Name = new NameType1 { Value = unvan };
        }
        return company;
    }

    private static AddressType Address(string adres, string ilce, string il)
    {
        AddressType address = new();
        if (adres.Trim() != "") address.StreetName = new StreetNameType { Value = adres };
        if (ilce.Trim() != "") address.CitySubdivisionName = new CitySubdivisionNameType { Value = ilce };
        if (il.Trim() != "") address.CityName = new CityNameType { Value = il };
        address.Country = new CountryType { Name = new NameType1 { Value = "TÜRKÝYE" }, IdentificationCode = new IdentificationCodeType { Value = "TR" } };
        return address;
    }

    private static ContactType? Contact(string email, string telefon)
    {
        ContactType? contact = null;
        if (email.Trim() != "" || telefon.Trim() != "")
        {
            contact = new();
            if (email.Trim() != "")
            {
                contact.ElectronicMail = new ElectronicMailType { Value = email };
            }
            if (telefon.Trim() != "")
            {
                contact.Telephone = new TelephoneType { Value = telefon };
            }
        }
        return contact;
    }

    private static PersonType? Person(string vknTckn, string ad, string soyad)
    {
        PersonType? person = null;
        if (vknTckn.Length == 11 && ad.Trim() == "" && soyad.Trim() == "")
        {
            throw new Exception("Þahýs olmasý durumunda ad, soyad zorunludur.");
        }
        if (ad.Trim() != "" && soyad.Trim() != "")
        {
            person = new();
            person.FirstName = new FirstNameType { Value = ad };
            person.FamilyName = new FamilyNameType { Value = soyad };
        }
        return person;
    }

    private TaxTotalType[] TaxTotal()
    {
        bool is0 = false, is1 = false, is10 = false, is20 = false;
        decimal tax1 = 0, tax10 = 0, tax20 = 0;
        decimal taxable0 = 0, taxable1 = 0, taxable10 = 0, taxable20 = 0;
        TaxSubtotalType? sub0 = null, sub1 = null, sub10 = null, sub20 = null;
        for (int i = 0; i < satir.Rows.Count - 1; i++)
        {
            if (C(satir.Rows[i].Cells["kdvOrani"]) == 0)
            {
                taxable0 += C(satir.Rows[i].Cells["malHizmetTutari"]);
                is0 = true;
            }
            else if (C(satir.Rows[i].Cells["kdvOrani"]) == 1)
            {
                tax1 += C(satir.Rows[i].Cells["kdvTutari"]);
                taxable1 += C(satir.Rows[i].Cells["malHizmetTutari"]);
                is1 = true;
            }
            else if (C(satir.Rows[i].Cells["kdvOrani"]) == 10)
            {
                tax10 += C(satir.Rows[i].Cells["kdvTutari"]);
                taxable10 += C(satir.Rows[i].Cells["malHizmetTutari"]);
                is10 = true;
            }
            else if (C(satir.Rows[i].Cells["kdvOrani"]) == 20)
            {
                tax20 += C(satir.Rows[i].Cells["kdvTutari"]);
                taxable20 += C(satir.Rows[i].Cells["malHizmetTutari"]);
                is20 = true;
            }
            else throw new Exception("KDV oraný 0, 1, 10 veya 20 olabilir.");
        }
        if (is0)
        {
            sub0 = new()
            {
                Percent = new PercentType1 { Value = 0 },
                TaxableAmount = new TaxableAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = taxable0 },
                TaxAmount = new TaxAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = 0 },
                TaxCategory = new TaxCategoryType
                {
                    TaxScheme = new TaxSchemeType
                    {
                        Name = new NameType1 { Value = "KDV" },
                        TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
                    },
                    TaxExemptionReasonCode = new TaxExemptionReasonCodeType { Value = istisnaKodu.SelectedValue?.ToString() },
                    TaxExemptionReason = new TaxExemptionReasonType { Value = istisnaKodu.Text }
                },
            };
        }
        if (is1)
        {
            sub1 = new()
            {
                Percent = new PercentType1 { Value = 1 },
                TaxableAmount = new TaxableAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = taxable1 },
                TaxAmount = new TaxAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = tax1 },
                TaxCategory = new TaxCategoryType
                {
                    TaxScheme = new TaxSchemeType
                    {
                        Name = new NameType1 { Value = "KDV" },
                        TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
                    }
                }
            };
        }
        if (is10)
        {
            sub10 = new()
            {
                Percent = new PercentType1 { Value = 10 },
                TaxableAmount = new TaxableAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = taxable10 },
                TaxAmount = new TaxAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = tax10 },
                TaxCategory = new TaxCategoryType
                {
                    TaxScheme = new TaxSchemeType
                    {
                        Name = new NameType1 { Value = "KDV" },
                        TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
                    }
                }
            };
        }
        if (is20)
        {
            sub20 = new()
            {
                Percent = new PercentType1 { Value = 20 },
                TaxableAmount = new TaxableAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = taxable20 },
                TaxAmount = new TaxAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = tax20 },
                TaxCategory = new TaxCategoryType
                {
                    TaxScheme = new TaxSchemeType
                    {
                        Name = new NameType1 { Value = "KDV" },
                        TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
                    }
                }
            };
        }
        TaxTotalType[] tax =
        [
            new TaxTotalType
            {
                TaxAmount = new TaxAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = decimal.Parse(hesaplananKdv.Text) },
                TaxSubtotal = [sub0, sub1, sub10, sub20]
            }
        ];
        return tax;
    }

    private MonetaryTotalType MonetaryTotal()
    {
        MonetaryTotalType dip = new()
        {
            LineExtensionAmount = new LineExtensionAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = decimal.Parse(malHizmetToplamTutari.Text) },
            TaxExclusiveAmount = new TaxExclusiveAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = decimal.Parse(malHizmetToplamTutari.Text) },
            TaxInclusiveAmount = new TaxInclusiveAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = decimal.Parse(vergilerDahilToplamTutar.Text) },
            AllowanceTotalAmount = new AllowanceTotalAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = decimal.Parse(toplamIskonto.Text) },
            PayableAmount = new PayableAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = decimal.Parse(odenecekTutar.Text) }
        };
        return dip;
    }

    private void Satir_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCellCollection s = satir.CurrentRow.Cells;
        s["olcu"].Value ??= "C62";
        s["siraNo"].Value = satir.CurrentRow.Index + 1;
        s["malHizmetTutari"].Value = C(s["miktar"]) * C(s["birimFiyat"]);
        s["iskontoTutari"].Value = C(s["malHizmetTutari"]) * C(s["iskontoOrani"]) / 100;
        s["malHizmetTutari"].Value = C(s["malHizmetTutari"]) - C(s["iskontoTutari"]);
        s["kdvTutari"].Value = C(s["malHizmetTutari"]) * C(s["kdvOrani"]) / 100;
        decimal toplam = 0, iskonto = 0, kdv = 0;
        DataGridViewRowCollection r = satir.Rows;
        for (int i = 0; i < r.Count; i++)
        {
            toplam += C(r[i].Cells["malHizmetTutari"]);
            iskonto += C(r[i].Cells["iskontoTutari"]);
            kdv += C(r[i].Cells["kdvTutari"]);
        }
        malHizmetToplamTutari.Text = (toplam + iskonto).ToString();
        toplamIskonto.Text = iskonto.ToString();
        hesaplananKdv.Text = kdv.ToString();
        vergilerDahilToplamTutar.Text = (toplam + kdv).ToString();
        odenecekTutar.Text = (toplam + kdv).ToString();
    }

    private InvoiceLineType[] InvoiceLines()
    {
        InvoiceLineType[] lines = new InvoiceLineType[satir.Rows.Count - 1];
        if (lines.Length < 1) throw new Exception("En az bir tane fatura satýrý bulunmalýdýr.");
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = new InvoiceLineType
            {
                ID = new IDType { Value = S(satir.Rows[i].Cells["siraNo"]) },
                InvoicedQuantity = new InvoicedQuantityType { unitCode = satir.Rows[i].Cells["olcu"].Value?.ToString(), Value = C(satir.Rows[i].Cells["miktar"]) },
                Price = new PriceType { PriceAmount = new PriceAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = C(satir.Rows[i].Cells["birimFiyat"]) } },
                LineExtensionAmount = new LineExtensionAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = C(satir.Rows[i].Cells["malHizmetTutari"]) },
                Item = new ItemType { Name = new NameType1 { Value = S(satir.Rows[i].Cells["malHizmet"]) } },
                TaxTotal = new TaxTotalType
                {
                    TaxAmount = new TaxAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = C(satir.Rows[i].Cells["kdvTutari"]) },
                    TaxSubtotal =
                    [
                        new() {
                            Percent = new PercentType1 { Value = C(satir.Rows[i].Cells["kdvOrani"]) },
                            TaxableAmount = new TaxableAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = C(satir.Rows[i].Cells["malHizmetTutari"]) },
                            TaxAmount = new TaxAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = C(satir.Rows[i].Cells["kdvTutari"]) },
                            TaxCategory = new TaxCategoryType
                            {
                                TaxScheme = new TaxSchemeType
                                {
                                    Name = new NameType1 { Value = "KDV" },
                                    TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
                                }
                            }
                        }
                    ]
                }
            };
            if (lines[i].TaxTotal.TaxSubtotal[0].Percent.Value == 0)
            {
                if (faturaTipi.Text != "ISTISNA")
                    throw new Exception("KDV tutarý sýfýr olmasý durumunda fatura tipi ISTISNA olmalýdýr.");
                lines[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxExemptionReasonCode = new TaxExemptionReasonCodeType { Value = istisnaKodu.SelectedValue?.ToString() };
                lines[i].TaxTotal.TaxSubtotal[0].TaxCategory.TaxExemptionReason = new TaxExemptionReasonType { Value = istisnaKodu.Text };
            }
            if (C(satir.Rows[i].Cells["iskontoTutari"]) > 0)
            {
                lines[i].AllowanceCharge =
                [
                    new() {
                        Amount = new AmountType2 { currencyID = paraBirimi.SelectedValue?.ToString(), Value = C(satir.Rows[i].Cells["iskontoTutari"]) },
                        ChargeIndicator = new ChargeIndicatorType { Value = false },
                        MultiplierFactorNumeric = new MultiplierFactorNumericType { Value = C(satir.Rows[i].Cells["iskontoOrani"]) / 100 },
                        BaseAmount = new BaseAmountType { currencyID = paraBirimi.SelectedValue?.ToString(), Value = C(satir.Rows[i].Cells["miktar"]) * C(satir.Rows[i].Cells["birimFiyat"]) },
                    }
                ];
            }
        }
        return lines;
    }

    private static decimal C(DataGridViewCell c)
    {
        c.Value ??= 0;
        _ = decimal.TryParse(c.Value.ToString(), out decimal result);
        return result;
    }

    private static string? S(DataGridViewCell c)
    {
        c.Value ??= "";
        return c.Value.ToString();
    }

    private void FaturaTipi_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (faturaTipi.Text == "IADE") groupBox6.Enabled = true;
        else groupBox6.Enabled = false;

        if (faturaTipi.Text == "ISTISNA")
        {
            label41.Enabled = true;
            istisnaKodu.Enabled = true;
        }
        else
        {
            label41.Enabled = false;
            istisnaKodu.Enabled = false;
        }
    }

    private void Senaryo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (senaryo.Text == "EARSIVFATURA")
        {
            label40.Enabled = true;
            gonderimSekli.Enabled = true;
        }
        else
        {
            label40.Enabled = false;
            gonderimSekli.Enabled = false;
        }
    }

    private void ParaBirimi_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (paraBirimi.SelectedValue?.ToString() == "TRY")
        {
            dovizKuru.Enabled = false;
            label28.Enabled = false;
            dovizKuru.Text = "1";
        }
        else
        {
            dovizKuru.Enabled = true;
            label28.Enabled = true;
        }
    }

    private void SaticiSehir_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Ilce> ilceler = [.. _saticiIlceler.Where(x => x.SehirId - 1 == saticiSehir.SelectedIndex)];
        saticiIlce.DataSource = ilceler;
        saticiIlce.ValueMember = "IlceId";
        saticiIlce.DisplayMember = "IlceAdi";
    }

    private void MusteriSehir_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Ilce> ilceler = [.. _musteriIlceler.Where(x => x.SehirId - 1 == musteriSehir.SelectedIndex)];
        musteriIlce.DataSource = ilceler;
        musteriIlce.ValueMember = "IlceId";
        musteriIlce.DisplayMember = "IlceAdi";
    }

    private static XmlDocument Serialize<T>(T type)
    {
        XmlSerializer serializer = new(typeof(T));
        using MemoryStream stream = new();
        XmlWriterSettings settings = new();
        settings.Indent = true;
        using XmlWriter xmlWriter = XmlWriter.Create(stream, settings);
        XmlSerializerNamespaces ns = new();
        ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
        ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
        ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
        serializer.Serialize(xmlWriter, type, ns);
        stream.Position = 0L;
        XmlDocument xml = new();
        xml.PreserveWhitespace = true;
        xml.Load(stream);
        return xml;
    }

    private byte[] Save()
    {
        string xmlPath = $"invoice/{faturaNo.Text}_{ettn.Text}.xml";
        InvoiceType inv = CreateInvoice();
        XmlDocument xmlDoc = Serialize(inv);
        Directory.CreateDirectory("invoice");
        byte[] fatura = Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
        File.WriteAllBytes(xmlPath, fatura);
        return fatura;
    }

    private void Preview()
    {
        Save();
        string html = XmlToHtml($"invoice/{faturaNo.Text}_{ettn.Text}.xml");
        string path = Path.Combine(Directory.GetCurrentDirectory(), html);
        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        });
    }

    private string XmlToHtml(string xmlPath)
    {
        XslCompiledTransform xslCompiledTransform = new();
        using MemoryStream ms = new(_template.Attachment.EmbeddedDocumentBinaryObject.Value);
        using XmlReader stylesheet = XmlReader.Create(ms);
        xslCompiledTransform.Load(stylesheet);
        string htmlPath = Path.ChangeExtension(xmlPath, ".html");
        xslCompiledTransform.Transform(xmlPath, htmlPath);
        return htmlPath;
    }

    private static async Task SendDocument(byte[] data)
    {
        using HttpClient client = InsecureHttpClient();
        using MemoryStream ms = new();
        using (GZipStream gzip = new(ms, CompressionLevel.Optimal, true))
        {
            gzip.Write(data, 0, data.Length);
        }
        ms.Position = 0;
        StreamContent content = new(ms);
        content.Headers.ContentEncoding.Add("gzip");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        HttpResponseMessage response = await client.PostAsync(ConfigurationManager.AppSettings.Get("DocumentApiUrl"), content);
        response.EnsureSuccessStatusCode();
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

    private static void FillUnitCodes(DataGridViewComboBoxColumn c)
    {
        Item[] items =
            [
            new Item("C62", "Adet"),
            new Item("BX", "Kutu"),
            new Item("PA", "Paket"),
            new Item("GRM", "g"),
            new Item("KGM", "kg"),
            new Item("LTR", "lt"),
            new Item("MTR", "m"),
            new Item("MTK", "m2"),
            new Item("MTQ", "m3"),
            new Item("HUR", "Saat"),
            new Item("DAY", "Gün"),
            new Item("MON", "Ay")
            ];
        c.DataSource = items;
        c.ValueMember = "Id";
        c.DisplayMember = "Ad";
    }

    private static void FillCurrencies(ComboBox c)
    {
        Item[] items =
            [
            new Item("TRY", "Türk Lirasý"),
            new Item("USD", "Amerikan Dolarý"),
            new Item("EUR", "Euro"),
            new Item("GBP", "Ýngiliz Sterlini"),
            new Item("CHF", "Ýsviçre Frangý")
            ];
        c.DataSource = items;
        c.ValueMember = "Id";
        c.DisplayMember = "Ad";
    }

    private static void FillExemptions(ComboBox c)
    {
        Item[] items =
            [
            new Item("311", "14/1 Uluslararasý Taþýmacýlýk"),
            new Item("335", "KDV 13/n Basýlý Kitap ve Süreli Yayýnlarýn Teslimleri"),
            new Item("341", "Afetzedelere Baðýþlanacak Konutlarýn Ýnþasýna Ýliþkin Ýstisna"),
            new Item("344", "13/o Milli Savunma ve Ýç Güvenlik Ýhtiyaçlarýnda Kullanýlmak Üzere Taþýt Teslimi"),
            new Item("351", "Diðerleri")
            ];
        c.DataSource = items;
        c.ValueMember = "Id";
        c.DisplayMember = "Ad";
    }

    private void Ac_Click(object sender, EventArgs e)
    {
        try
        {
            string? filePath = null;
            using (OpenFileDialog dialog = new())
            {
                dialog.Filter = "XML Files (*.xml)|*.xml";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
            }
            if (filePath == null) return;
            XmlSerializer serializer = new(typeof(InvoiceType));
            InvoiceType? inv;
            using FileStream fs = new(filePath, FileMode.Open);
            inv = (InvoiceType?)serializer.Deserialize(fs) ?? throw new Exception("Fatura yüklenemedi.");
            senaryo.Text = inv.ProfileID.Value;
            faturaTipi.Text = inv.InvoiceTypeCode.Value;
            ettn.Text = inv.UUID.Value;
            faturaNo.Text = inv.ID.Value;
            faturaTarihi.Value = inv.IssueDate.Value;
            irsaliyeNumarasi.Text = inv.DespatchDocumentReference?[0].ID.Value ?? "";
            irsaliyeTarihi.Value = inv.DespatchDocumentReference?[0].IssueDate.Value ?? DateTime.Now;
            siparisNumarasi.Text = inv.OrderReference?.ID.Value ?? "";
            siparisTarihi.Value = inv.OrderReference?.IssueDate.Value ?? DateTime.Now;
            iadeFaturaNo.Text = inv.BillingReference?[0].InvoiceDocumentReference.ID.Value ?? "";
            iadeFaturaTarihi.Value = inv.BillingReference?[0].InvoiceDocumentReference.IssueDate.Value ?? DateTime.Now;
            _template.Attachment.EmbeddedDocumentBinaryObject.filename = inv.AdditionalDocumentReference?.FirstOrDefault(x => x.DocumentTypeCode?.Value == "XSLT")?.Attachment.EmbeddedDocumentBinaryObject.filename ?? "general.xslt";
            _template.Attachment.EmbeddedDocumentBinaryObject.Value = inv.AdditionalDocumentReference?.FirstOrDefault(x => x.DocumentTypeCode?.Value == "XSLT")?.Attachment.EmbeddedDocumentBinaryObject.Value ?? File.ReadAllBytes("xslt/general.xslt");
            gonderimSekli.Text = inv.AdditionalDocumentReference?.FirstOrDefault(x => x.DocumentTypeCode?.Value == "SendingType")?.DocumentType.Value ?? "";
            paraBirimi.SelectedValue = inv.DocumentCurrencyCode.Value;
            dovizKuru.Text = inv.PricingExchangeRate?.CalculationRate.Value.ToString() ?? "1";
            not.Lines = inv.Note?.Select(x => x.Value).ToArray();
            saticiVergiNo.Text = inv.AccountingSupplierParty.Party.PartyIdentification.FirstOrDefault(x => x.ID.schemeID == "VKN" || x.ID.schemeID == "TCKN")?.ID.Value;
            saticiUnvan.Text = inv.AccountingSupplierParty.Party.PartyName?.Name.Value ?? "";
            saticiVergiDairesi.Text = inv.AccountingSupplierParty.Party.PartyTaxScheme?.TaxScheme.Name.Value ?? "";
            saticiAdres.Text = inv.AccountingSupplierParty.Party.PostalAddress?.StreetName.Value ?? "";
            saticiIlce.Text = inv.AccountingSupplierParty.Party.PostalAddress?.CitySubdivisionName.Value ?? "";
            saticiSehir.Text = inv.AccountingSupplierParty.Party.PostalAddress?.CityName.Value ?? "";
            saticiEposta.Text = inv.AccountingSupplierParty.Party.Contact?.ElectronicMail.Value ?? "";
            saticiTelefon.Text = inv.AccountingSupplierParty.Party.Contact?.Telephone.Value ?? "";
            saticiAd.Text = inv.AccountingSupplierParty.Party.Person?.FirstName.Value ?? "";
            saticiSoyad.Text = inv.AccountingSupplierParty.Party.Person?.FamilyName.Value ?? "";

            musteriVergiNo.Text = inv.AccountingCustomerParty.Party.PartyIdentification.FirstOrDefault(x => x.ID.schemeID == "VKN" || x.ID.schemeID == "TCKN")?.ID.Value;
            musteriUnvan.Text = inv.AccountingCustomerParty.Party.PartyName?.Name.Value ?? "";
            musteriVergiDairesi.Text = inv.AccountingCustomerParty.Party.PartyTaxScheme?.TaxScheme.Name.Value ?? "";
            musteriAdres.Text = inv.AccountingCustomerParty.Party.PostalAddress?.StreetName.Value ?? "";
            musteriIlce.Text = inv.AccountingCustomerParty.Party.PostalAddress?.CitySubdivisionName.Value ?? "";
            musteriSehir.Text = inv.AccountingCustomerParty.Party.PostalAddress?.CityName.Value ?? "";
            musteriEposta.Text = inv.AccountingCustomerParty.Party.Contact?.ElectronicMail.Value ?? "";
            musteriTelefon.Text = inv.AccountingCustomerParty.Party.Contact?.Telephone.Value ?? "";
            musteriAd.Text = inv.AccountingCustomerParty.Party.Person?.FirstName.Value ?? "";
            musteriSoyad.Text = inv.AccountingCustomerParty.Party.Person?.FamilyName.Value ?? "";

            istisnaKodu.SelectedValue = inv.TaxTotal[0].TaxSubtotal.FirstOrDefault(x => x.Percent.Value == 0)?.TaxCategory.TaxExemptionReasonCode.Value ?? "";
            istisnaKodu.Text = inv.TaxTotal[0].TaxSubtotal.FirstOrDefault(x => x.Percent.Value == 0)?.TaxCategory.TaxExemptionReason.Value ?? "";

            toplamIskonto.Text = inv.LegalMonetaryTotal.AllowanceTotalAmount.Value.ToString();
            malHizmetToplamTutari.Text = inv.LegalMonetaryTotal.LineExtensionAmount.Value.ToString();
            hesaplananKdv.Text = inv.TaxTotal[0].TaxAmount.Value.ToString();
            vergilerDahilToplamTutar.Text = inv.LegalMonetaryTotal.TaxInclusiveAmount.Value.ToString();
            odenecekTutar.Text = inv.LegalMonetaryTotal.PayableAmount.Value.ToString();

            satir.Rows.Clear();
            for (int i = 0; i < inv.InvoiceLine.Length; i++)
            {
                satir.Rows.Add(
                    inv.InvoiceLine[i].ID.Value,
                    inv.InvoiceLine[i].Item.Name.Value,
                    inv.InvoiceLine[i].InvoicedQuantity.Value,
                    inv.InvoiceLine[i].InvoicedQuantity.unitCode,
                    inv.InvoiceLine[i].Price.PriceAmount.Value,
                    inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].Percent.Value,
                    inv.InvoiceLine[i].TaxTotal.TaxSubtotal[0].TaxAmount.Value,
                    inv.InvoiceLine[i].AllowanceCharge?[0].MultiplierFactorNumeric.Value * 100 ?? 0,
                    inv.InvoiceLine[i].AllowanceCharge?[0].Amount.Value ?? 0,
                    inv.InvoiceLine[i].LineExtensionAmount.Value
                );
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Directory.CreateDirectory("log");
            File.AppendAllText("log/error.log", ex.StackTrace);
        }
    }

    private void Temizle_Click(object sender, EventArgs e)
    {
        foreach (Control c in groupBox1.Controls)
        {
            if (c is TextBox box) box.Clear();
        }

        foreach (Control c in groupBox2.Controls)
        {
            if (c is TextBox box) box.Clear();
        }

        foreach (Control c in groupBox3.Controls)
        {
            if (c is TextBox box) box.Clear();
            else if (c is ComboBox combo) combo.SelectedIndex = 0;
            else if (c is DateTimePicker date) date.Value = DateTime.Now;
        }
        saticiSehir.SelectedIndex = 33;
        saticiIlce.SelectedIndex = 0;
        musteriSehir.SelectedIndex = 33;
        musteriIlce.SelectedIndex = 0;

        irsaliyeNumarasi.Clear();
        siparisNumarasi.Clear();
        iadeFaturaNo.Clear();
        satir.Rows.Clear();
        not.Clear();

        malHizmetToplamTutari.Text = "0";
        toplamIskonto.Text = "0";
        hesaplananKdv.Text = "0";
        vergilerDahilToplamTutar.Text = "0";
        odenecekTutar.Text = "0";
    }

    private void SablonSec_Click(object sender, EventArgs e)
    {
        using OpenFileDialog dialog = new();
        dialog.Filter = "Template Files (*.xslt)|*.xslt|Template Files (*.xsl)|*.xsl";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _template.Attachment.EmbeddedDocumentBinaryObject.filename = Path.GetFileName(dialog.FileName);
            _template.Attachment.EmbeddedDocumentBinaryObject.Value = File.ReadAllBytes(dialog.FileName);
        }
    }
}