namespace berloga.Models.Repositories
{
    public class TypeOfApartamentRepository : BaseRepository<TypeOfApartament>, ITypeOfApartamentRepository
    {
        public TypeOfApartamentRepository(berlogaContext berlogaContext) : base(berlogaContext)
        {
        }
    }
}