namespace EFaturaForm
{
    internal record Item(string Id, string Ad);

    internal record Sehir(int SehirId, string SehirAdi);

    internal record Ilce(int IlceId, string IlceAdi, int SehirId);
}