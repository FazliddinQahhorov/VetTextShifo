namespace VetTextShifo.Application.Confugrations;


public class PaginationParams
{
    private const int _maxPageSize = 20;
    public int PageIndex { get; set; } = 1;
    private int _pageSize;
    public int PageSize
    {
        get => _pageSize == 0 ? 10 : _pageSize;
        set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
    }
}