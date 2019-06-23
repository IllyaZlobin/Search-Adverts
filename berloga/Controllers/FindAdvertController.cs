using berloga.Models;
using berloga.Models.Repositories;
using berloga.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace berloga.Controllers
{
    public class FindAdvertController : Controller
    {
        private readonly berlogaContext _context;
        private IRepositoryWrapper _repositoryWrapper;

        public FindAdvertController(berlogaContext context, IRepositoryWrapper repositoryWrapper)
        {
            _context = context;
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Find(string towndistrict, string price)
        {
            FindAdvertViewModel findAdvertViewModel = new FindAdvertViewModel();
            findAdvertViewModel.TownDistrict = towndistrict;
            findAdvertViewModel.Price = Convert.ToDouble(price);
            findAdvertViewModel.AllAdverts = _context.AllAdverts.Include(i => i.IdUserNavigation).Include(i => i.IdAdvertsNavigation)
                .Include(i => i.IdApartamentNavigation).Where(i => i.TownDistrict == towndistrict && i.Price > findAdvertViewModel.Price);
            return View(findAdvertViewModel.AllAdverts);
        }
    }
}