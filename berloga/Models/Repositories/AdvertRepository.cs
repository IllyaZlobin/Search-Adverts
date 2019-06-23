namespace berloga.Models.Repositories
{
    public class AdvertRepository : BaseRepository<AllAdverts>, IAdvertRepository
    {
        public AdvertRepository(berlogaContext berlogaContext) : base(berlogaContext)
        {
        }
    }
}