namespace berloga.Models.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private berlogaContext _context;
        private IAdvertRepository _advert;
        private ITypeOfAdvertRepository _typeOfAdvert;
        private ITypeOfApartamentRepository _typeOfApartament;

        public IAdvertRepository Advert
        {
            get
            {
                if (_advert == null)
                {
                    _advert = new AdvertRepository(_context);
                }

                return _advert;
            }
        }

        public ITypeOfAdvertRepository TypeOfAdvert
        {
            get
            {
                if (_typeOfAdvert == null)
                {
                    _typeOfAdvert = new TypeOfAdvertRepository(_context);
                }

                return _typeOfAdvert;
            }
        }

        public ITypeOfApartamentRepository TypeOfApartament
        {
            get
            {
                if (_typeOfApartament == null)
                {
                    _typeOfApartament = new TypeOfApartamentRepository(_context);
                }

                return _typeOfApartament;
            }
        }

        public RepositoryWrapper(berlogaContext BerlogaContext)
        {
            _context = BerlogaContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}