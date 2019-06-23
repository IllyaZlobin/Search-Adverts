using System.Collections.Generic;

namespace berloga.Models
{
    public partial class TypeOfApartament
    {
        public TypeOfApartament()
        {
            AllAdverts = new HashSet<AllAdverts>();
        }

        public int IdApartament { get; set; }
        public string TypeOfApartament1 { get; set; }

        public ICollection<AllAdverts> AllAdverts { get; set; }
    }
}