namespace Rentaly.Application.UseCases.Queries;
public class PagedResponse<T> where T : class
{
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int PagesCount
    {
        get
        {
            return (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
        }
    }

    public IEnumerable<T> Data { get; set; }
}
