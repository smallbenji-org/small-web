namespace SmallEnergy.Interfaces
{
    public interface IPagination
    {
        int getMaxPages(int count, int pageSize);
        List<T> GetPage<T>(int pageSize, int currentPage, List<T> list);
    }
}
