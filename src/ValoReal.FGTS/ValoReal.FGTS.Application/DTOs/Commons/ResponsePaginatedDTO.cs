namespace ValoReal.FGTS.Application.Commons;

public class PaginatedResponseDTO<T> where T : class
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }

    public PaginatedResponseDTO() { }

    public PaginatedResponseDTO(
        IEnumerable<T> items,
        int totalRecords,
        int currentPage,
        int pageSize)
    {
        Items = items;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
    }

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
}
