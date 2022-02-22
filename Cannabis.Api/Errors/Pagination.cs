namespace Cannabis.Api.Errors;

public class Pagination<T> where T : class
{
    public Pagination(int pageIdex, int pageSize, int count, IEnumerable<T> data)
    {
        PageSize = pageIdex;
        PageIndex = pageSize;
        Count = count;
        Data = data;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public IEnumerable<T> Data { get; set; }
}
