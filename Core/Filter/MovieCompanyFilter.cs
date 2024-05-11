namespace Core.Filter;

public class MovieCompanyFilter
{
    public int? Movie_Id { get; set; }
    public int? Company_Id { get; set; }
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 10;
    public string SortBy { get; set; } = string.Empty;
    public int? SortDirection { get; set; }
}
