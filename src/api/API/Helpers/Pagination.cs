namespace API.Helpers;

public class Pagination<T>(int pageIndex, int pageSize, int count,int pages, IReadOnlyList<T>? data)
{
    public int PageIndex { get; set; } = pageIndex;
    public int PageSize { get; set; } = pageSize;
    public int Count { get; set; } = count;
    public IReadOnlyList<T>? Data { get; set; } = data;
    public int TotalPages { get; set; } = pages;
}
