namespace Reconcile.Graphql.Schema.Extensions
{

    public static class PagingExtensions
        {
            public static IQueryable<T> Paging<T>(this IQueryable<T> source, int pageNo, int pageSize)
            {
                if (pageNo < 1)
                {
                    pageNo = 1;
                }

                if (pageSize < 1)
                {
                    pageSize = 25;
                }

                return source.Skip((pageNo - 1) * pageSize).Take(pageSize);
            }

            public static IEnumerable<T> Paging<T>(this IEnumerable<T> source, int pageNo, int pageSize)
            {
                if (pageNo < 1)
                {
                    pageNo = 1;
                }

                if (pageSize < 1)
                {
                    pageSize = 25;
                }

                return source.Skip((pageNo - 1) * pageSize).Take(pageSize);
            }
        }
    }
