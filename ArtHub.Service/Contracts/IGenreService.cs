using ArtHub.BusinessObject;

namespace ArtHub.Service.Contracts
{
    public interface IGenreService
    {
        Task<IList<Genre>> GetGenresAsync();
    }
}
