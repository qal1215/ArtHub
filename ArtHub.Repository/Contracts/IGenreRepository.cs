using ArtHub.BusinessObject;

namespace ArtHub.Repository.Contracts
{
    public interface IGenreRepository
    {
        Task<Genre?> SearchGenreByName(string genreName);

        Task<Genre> AddGenre(string genreName);

        Task<IList<Genre>> GetGenresAsync();
    }
}
