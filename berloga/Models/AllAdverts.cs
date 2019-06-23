namespace berloga.Models
{
    public partial class AllAdverts
    {
        public int IdHome { get; set; }
        public int IdAdverts { get; set; }
        public string IdUser { get; set; }
        public int IdApartament { get; set; }
        public string TownDistrict { get; set; }
        public string Adress { get; set; }
        public int NumOfRooms { get; set; }
        public double Square { get; set; }
        public string AboutHome { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public TypeOfAdvert IdAdvertsNavigation { get; set; }
        public TypeOfApartament IdApartamentNavigation { get; set; }
        public AspNetUsers IdUserNavigation { get; set; }
    }
}