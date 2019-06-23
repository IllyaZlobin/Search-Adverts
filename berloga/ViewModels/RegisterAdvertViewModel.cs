using berloga.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace berloga.ViewModels
{
    public class RegisterAdvertViewModel
    {
        public int IdSelectedAdvert { get; set; }
        public string IdUser { get; set; }
        public int IdSelectedApartament { get; set; }
        public string TownDistrict { get; set; }
        public string Adress { get; set; }
        public int NumOfRooms { get; set; }
        public double Square { get; set; }
        public string AboutHome { get; set; }
        public double Price { get; set; }

        public IFormFile Image { get; set; }

        public IQueryable<TypeOfAdvert> AdvertList { get; set; }
        public IQueryable<TypeOfApartament> ApartamentList { get; set; }
    }
}