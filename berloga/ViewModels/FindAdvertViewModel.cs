using berloga.Models;
using System.Linq;

namespace berloga.ViewModels
{
    public class FindAdvertViewModel
    {
        public double Price { get; set; }
        public string TownDistrict { get; set; }

        public IQueryable<AllAdverts> AllAdverts { get; set; }
    }
}