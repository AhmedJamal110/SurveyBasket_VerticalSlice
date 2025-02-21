namespace SurveyBasket_VerticalSlice.Comman;

public record RequestFilter
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? SearchTerm { get; init; }
    public string?  SortColumn { get; set; }
    public string?  SortDirection { get; set; } = "ASC";


}
