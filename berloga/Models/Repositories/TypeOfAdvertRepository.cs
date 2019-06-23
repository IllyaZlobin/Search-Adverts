namespace berloga.Models.Repositories
{
    public class TypeOfAdvertRepository : BaseRepository<TypeOfAdvert>, ITypeOfAdvertRepository
    {
        public TypeOfAdvertRepository(berlogaContext berlogaContext) : base(berlogaContext)
        {
        }
    }
}