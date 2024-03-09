using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.Repository.Contracts;

namespace ArtHub.Repository
{
    public class GenreRepository : IGenreRepository
    {
        public async Task<Genre> AddGenre(string genreName)
        {
            return await GenreDAO.Instance.CreateGenre(genreName);
        }

        public async Task<IList<Genre>> GetGenresAsync()
            => await GenreDAO.Instance.GetAllGenres();

        public async Task<Genre?> SearchGenreByName(string genreName)
        {
            return await GenreDAO.Instance.SearchGenreByName(genreName);
        }
    }
}
