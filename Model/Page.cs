namespace EFaturaForm.Model;

public class Page
{
    public int TotalRecords { get; set; }
    public int PageCount { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }

    public List<Document>? Data { get; set; }
}
