namespace Common.Models.Paging
{
    public class PageInfo : PageInfo<string>
    {
    }

    public class PageInfo<T> : IPageInfo<T>
    {
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public T? StartCursor { get; set; }
        public T EndCursor { get; set; }

        public PageInfo() { }

        public PageInfo(bool hasNextPage, bool hasPreviousPage, T startCursor, T endCursor)
        {
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            StartCursor = startCursor;
            EndCursor = endCursor;
        }
    }
}
