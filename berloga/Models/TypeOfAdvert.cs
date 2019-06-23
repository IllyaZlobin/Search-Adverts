using System.Collections.Generic;

namespace berloga.Models
{
    public partial class TypeOfAdvert
    {
        public TypeOfAdvert()
        {
            AllAdverts = new HashSet<AllAdverts>();
        }

        public int IdAdvert { get; set; }
        public string TypeOfAdvert1 { get; set; }

        public ICollection<AllAdverts> AllAdverts { get; set; }
    }
}