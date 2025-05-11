namespace Core.Specifications;

public class BookSpecParams
{
    private List<string> _genres = [];
    private const int MaxPageSize = 50;
    public List<string> Genres
    {
        get => _genres;
        set
        {
            _genres = value.SelectMany(x => x.Split(",",StringSplitOptions.RemoveEmptyEntries))
                .Select(x => x.Trim())
                .ToList();
        }
    }

    private List<string> _authors = [];

    public List<string> Authors
    {
        get => _authors;
        set
        {
            _authors = value.SelectMany(x => x.Split(",", StringSplitOptions.RemoveEmptyEntries))
                .Select(x => x.Trim())
                .ToList();
        }
    }
    public string? Sort { get; set; }

    private string _search = string.Empty;

    public string Search
    {
        get => _search;
        set => _search = value.Trim().ToLower();
    }

    public int PageIndex { get; set; } = 1;

    private int _pageSize = 6;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize =  value > MaxPageSize ? MaxPageSize : value;
    }

    public bool IsPaginationEnabled { set; get; } = false;
}
