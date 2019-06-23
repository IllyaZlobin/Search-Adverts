namespace berloga.Models.Repositories
{
    public interface IRepositoryWrapper
    {
        IAdvertRepository Advert { get; }
        ITypeOfAdvertRepository TypeOfAdvert { get; }

        ITypeOfApartamentRepository TypeOfApartament { get; }

        void Save();
    }
}