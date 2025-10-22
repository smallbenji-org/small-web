using AccesPoint.Models;

namespace SmallEnergy.Models
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public List<string> Searches { get; set; }
        public PaginationViewModel Pagination = new();
        public string filter { get; set; }
    }
}
