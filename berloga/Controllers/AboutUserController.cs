using berloga.Models;
using berloga.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace berloga.Controllers
{
    public class AboutUserController : Controller
    {
        private UserManager<Users> _userManager;
        private readonly berlogaContext _context;

        public AboutUserController(UserManager<Users> userManager, berlogaContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            Users user = await _userManager.FindByNameAsync(name);
            if (user != null)
            {
                AboutUserViewModel model = new AboutUserViewModel
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    name = user.name,
                    surname = user.surname,
                    about_yourstlf = user.about_yourstlf
                };
                return View(model);
            }

            return NotFound();
        }
    }
}