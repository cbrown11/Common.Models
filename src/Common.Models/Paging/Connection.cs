
namespace Common.Models.Paging
{
    public class Connection<TNodeType> : Connection<TNodeType, string> where TNodeType : class
    {
        public Connection(IEnumerable<TNodeType> nodes, IPageInfo<string> pageInfo)
            :base(nodes, pageInfo)
        {
        }
    }

    public class Connection<TNodeType,TPageInfoType> where TNodeType : class 
                                 
    {
        public IEnumerable<TNodeType> Nodes { get; set; }

        public IPageInfo<TPageInfoType> PageInfo { get; set; }

        public Connection() { }

        public Connection(IEnumerable<TNodeType> nodes, IPageInfo<TPageInfoType> pageInfo)
        {
            PageInfo = pageInfo;
            Nodes = nodes;
        }
    }
}
