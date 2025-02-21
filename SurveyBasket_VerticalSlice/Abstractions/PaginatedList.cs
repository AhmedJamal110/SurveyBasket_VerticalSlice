namespace SurveyBasket_VerticalSlice.Abstractions;

public class PaginatedList<T>
{
    public PaginatedList(List<T> data , int pageNumber , int count , int pageSize)
    {
        Data = data;
        PageNmber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public List<T> Data { get; private set; }
    public int PageNmber { get; private set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage => PageNmber > 1;
    public bool HasNextPage => PageNmber  < TotalPages;

    public static async Task<PaginatedList<T>> CreatetAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        int count = await source.CountAsync();
        var data = await source.Skip((pageNumber - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToListAsync();


        return new PaginatedList<T>(data , pageNumber , count , pageSize);
    }

}
