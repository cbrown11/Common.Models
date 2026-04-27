using Common.Models.Paging;


namespace Common.UnitTests.Stubs
{
    public class TestGraphPageInfo : PageInfo
    {
        public TestGraphPageInfo(string? after, string pageState, bool hasNextPage)

        {
            string endCursor = pageState;
            HasPreviousPage = !string.IsNullOrEmpty(after);
            HasNextPage = hasNextPage;
            StartCursor = after;
            EndCursor = endCursor;
        }
    }
}
