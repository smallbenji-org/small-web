using AccesPoint.Models;

namespace SmallEnergy.Models
{
    public class AnalyticViewModel
    {
        public List<(string, int)> Searches { get; set; }
        public PaginationViewModel Pagination = new();
        public string filter { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}
