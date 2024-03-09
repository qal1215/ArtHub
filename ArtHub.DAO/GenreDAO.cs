using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.DAO
{
    public class GenreDAO
    {
        private static GenreDAO instance = null;

        private readonly ArtHub2024DbContext dbContext = null;

        public GenreDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static GenreDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GenreDAO();
                }
                return instance;
            }
        }

        public async Task<IList<Genre>> GetAllGenres()
        {
            return await dbContext.Genres.ToListAsync();
        }

        public async Task<Genre?> SearchGenreByName(string genreName)
        {
            return await dbContext.Genres.FirstOrDefaultAsync(g => g.Name.Equals(genreName));
        }

        public async Task<Genre> CreateGenre(string genreName)
        {
            Genre genre = new Genre
            {
                Name = genreName
            };
            await dbContext.Genres.AddAsync(genre);
            await dbContext.SaveChangesAsync();
            return genre;
        }
    }
}
