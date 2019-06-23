using berloga.Models;
using System.Linq;

namespace berloga.ViewModels
{
    public class AdvertViewModel
    {
        public IQueryable<AllAdverts> allAdverts { get; set; }
    }
}