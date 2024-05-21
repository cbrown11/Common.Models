namespace Common.Models.Paging
{
    public interface IPageInfo: IPageInfo<string>
    {
    }

    public interface IPageInfo<T>
    {
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
        T StartCursor { get; }
        T EndCursor { get; }
    }
}