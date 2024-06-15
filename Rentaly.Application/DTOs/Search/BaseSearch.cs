namespace Rentaly.Application.DTOs.Search;
public class BaseSearch
{
    public string? Keyword { get; set; }
}

public class PagedSearch
{
    public int? PerPage { get; set; } = 15;
    public int? Page { get; set; } = 1;
}

public class CarPagedSearchDto : PagedSearch
{
    public string? Keyword { get; set; }
    public DateOnly? YearFrom { get; set; }
    public DateOnly? YearTo { get; set; }
    public string? VIN { get; set; }
    public float? MoreThenKilometars { get; set; }
    public float? LessTheKilometars { get; set; }
    public IEnumerable<int>? CarType {  get; set; }
    public string? SortBy { get; set; }
}