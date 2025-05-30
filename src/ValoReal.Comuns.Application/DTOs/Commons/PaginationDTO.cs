namespace ValoReal.Comuns.Application.DTOs.Commons;

public class PaginacaoDTO
{
    private int _pageNumber = 1;
    private int _pageSize = 10;
    private const int MaxPageSize = 50;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value < 1 ? 1 : value;
    }
}
