using SmallEnergy.Interfaces;

namespace EmilsAuto.Helper
{
    public class Pagination : IPagination
    {
        public int getMaxPages(int count, int pageSize)
        {
            return Convert.ToInt32(Math.Ceiling((decimal)count / pageSize));
        }
        public List<T> GetPage<T>(int pageSize, int currentPage, List<T> list)
        {
            int startIndex = pageSize * (currentPage - 1);
            if (startIndex >= list.Count)
                return new List<T>();
            int count = Math.Min(pageSize, list.Count - startIndex);
            return list.GetRange(startIndex, count);
        }
    }
}
