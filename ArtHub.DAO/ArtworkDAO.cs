using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArtHub.DAO
{
    public class ArtworkDAO
    {
        private static ArtworkDAO instance = null;
        private readonly ArtHub2024DbContext _dbContext = null;

        public ArtworkDAO()
        {
            if (_dbContext is null)
            {
                _dbContext = new ArtHub2024DbContext();
            }
        }

        public static ArtworkDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArtworkDAO();
                }
                return instance;
            }
        }

        public async Task<Artwork?> GetArtwork(int id)
        {
            return await _dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkId == id);
        }

        public async Task<List<Artwork>> GetArtworksAsync()
        {
            return await _dbContext.Artworks.ToListAsync();
        }

        public async Task<Artwork> AddArtworkAsync(Artwork artwork)
        {
            await _dbContext.AddAsync(artwork);
            await _dbContext.SaveChangesAsync();
            return artwork;
        }

        public async Task<List<Artwork>> GetArtworksByArtistAsync(int artistID)
        {
            return await _dbContext.Artworks.Where(a => a.ArtistID == artistID).ToListAsync();
        }

        public async Task<Artwork> UpdateArtWorkAsync(int id, Artwork artwork)
        {
            var artworkToUpdate = await _dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkId == id);
            if (artworkToUpdate != null)
            {
                artworkToUpdate.Name = artwork.Name;
                artworkToUpdate.Description = artwork.Description;
                artworkToUpdate.Image = artwork.Image;
                artworkToUpdate.Price = artwork.Price;
                artworkToUpdate.IsPublic = artwork.IsPublic;
                artworkToUpdate.IsBuyAvailable = artwork.IsBuyAvailable;
                await _dbContext.SaveChangesAsync();
            }

            return artworkToUpdate!;
        }

        public async Task<bool> IsExistArtwork(int id)
        {
            return await _dbContext.Artworks.AnyAsync(a => a.ArtworkId == id);
        }

        public async Task DeleteArtworkAsync(int id)
        {
            var artwork = await _dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkId == id);
            if (artwork != null)
            {
                _dbContext.Remove(artwork);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Artwork>> GetArtworks(Expression<Func<Artwork, bool>> expression)
            => await _dbContext.Artworks.Where(expression).ToListAsync();

        public async Task<PagedResult<Artwork>> GetArtworksPaging(int page, int pageSize, string q)
        {
            var artworks = await _dbContext.Artworks
                .Where(artwork => artwork.Description.ToUpper().Contains(q)
                || artwork.Name.ToUpper().Contains(q)
                || artwork.Genre.Name.ToUpper().Contains(q))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalItem = await _dbContext.Artworks
                .Where(artwork => artwork.Description.ToUpper().Contains(q)
                || artwork.Name.ToUpper().Contains(q)
                || artwork.Genre.Name.ToUpper().Contains(q))
                .CountAsync();
            decimal totalPages = (decimal)totalItem / pageSize;

            return new PagedResult<Artwork>
            {
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Round(totalPages),
                TotalItems = totalItem,
                Items = artworks
            };
        }

        public async Task<IEnumerable<int>> GetMembersRated(int artworkId)
        {
            return await _dbContext.Ratings
                .Where(r => r.ArtworkId == artworkId)
                .Select(r => r.MemberId)
                .ToListAsync();
        }
    }
}
