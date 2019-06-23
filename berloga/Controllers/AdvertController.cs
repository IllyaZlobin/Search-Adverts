using berloga.Models;
using berloga.Models.Repositories;
using berloga.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace berloga.Controllers
{
    public class AdvertController : Controller
    {
        private UserManager<Users> _userManager;
        private readonly berlogaContext _context;
        private IRepositoryWrapper _repositoryWrapper;
        private static string userId;

        public AdvertController(UserManager<Users> userManager, berlogaContext context, IRepositoryWrapper repositoryWrapper)
        {
            _userManager = userManager;
            _context = context;
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> MyAdverts(string name)
        {
            Users user = await _userManager.FindByNameAsync(name);
            AdvertViewModel advertViewModel = new AdvertViewModel();
            advertViewModel.allAdverts = _repositoryWrapper.Advert.FindByCondition(i => i.IdUser == user.Id);
            var AllAdvertses = _context.AllAdverts.Include(i => i.IdUserNavigation).Include(i => i.IdAdvertsNavigation)
                .Include(i => i.IdApartamentNavigation).Where(i => i.IdUser == user.Id);
            return View(AllAdvertses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(RegisterAdvertViewModel advertModel)
        {
            AdvertViewModel advertViewModel = new AdvertViewModel();
            advertViewModel.allAdverts = _repositoryWrapper.Advert.findAll();
            int advertsCount = advertViewModel.allAdverts.Count() + 1;

            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(advertModel.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)advertModel.Image.Length);
                }
                AllAdverts advert = new AllAdverts
                {
                    IdHome = advertsCount + 1,
                    IdAdverts = advertModel.IdSelectedAdvert,
                    IdUser = userId,
                    IdApartament = advertModel.IdSelectedApartament,
                    TownDistrict = advertModel.TownDistrict,
                    Adress = advertModel.Adress,
                    NumOfRooms = advertModel.NumOfRooms,
                    Square = advertModel.Square,
                    AboutHome = advertModel.AboutHome,
                    Price = advertModel.Price,
                    Image = imageData
                };
                if (advert != null)
                {
                    _context.AllAdverts.Add(advert);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdvert(string name)
        {
            Users user = await _userManager.FindByNameAsync(name);
            userId = user.Id;
            RegisterAdvertViewModel registerAdvert = new RegisterAdvertViewModel();
            registerAdvert.AdvertList = _repositoryWrapper.TypeOfAdvert.findAll();
            registerAdvert.ApartamentList = _repositoryWrapper.TypeOfApartament.findAll();
            return View(registerAdvert);
        }
    }
}