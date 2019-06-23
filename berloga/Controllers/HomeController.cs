using berloga.Models;
using berloga.Models.Repositories;
using berloga.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace berloga.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<Users> _userManager;
        private readonly berlogaContext _context;
        private IRepositoryWrapper _repositoryWrapper;

        public HomeController(UserManager<Users> userManager, berlogaContext context, IRepositoryWrapper repositoryWrapper)
        {
            _userManager = userManager;
            _context = context;
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allAdverts = _context.AllAdverts.Include(i => i.IdUserNavigation).Include(i => i.IdAdvertsNavigation)
               .Include(i => i.IdApartamentNavigation);
            return View(allAdverts);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Developer()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}