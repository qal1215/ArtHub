using ArtHub.BusinessObject;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public GenreRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> AddGenre(string genreName)
        {
            Genre genre = new Genre
            {
                Name = genreName
            };
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<IList<Genre>> GetGenresAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<Genre?> SearchGenreByName(string genreName)
        {
            return await _dbContext.Genres.FirstOrDefaultAsync(g => g.Name.Equals(genreName));
        }
    }
}
