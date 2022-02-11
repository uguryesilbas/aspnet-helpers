namespace Helpers
{
    public class PagingHelper
    {
        public static int CalculatePageCount(int totalCount, int pageSize)
        {
            int pageCount = 0;

            if (pageSize <= 0) return pageCount;

            if (totalCount % pageSize > 0)
                pageCount = (totalCount / pageSize) + 1;
            else
                pageCount = (totalCount / pageSize);
            return pageCount;
        }
    }
}
