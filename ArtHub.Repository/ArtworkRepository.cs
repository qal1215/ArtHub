using ArtHub.BusinessObject;
using ArtHub.DTO.ModelResult;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArtHub.Repository
{
    public class ArtworkRepository : IArtworkRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public ArtworkRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsBuyAvailable(int artworkId)
        {
            var isBuyAvailable = await _dbContext.Artworks
                .AnyAsync(a => a.ArtworkId == artworkId && a.IsBuyAvailable && a.IsPublic);
            return isBuyAvailable;
        }

        public async Task<decimal> GetTotalPriceByArtworkIds(int[] artworkIds)
        {
            var totalAmount = await _dbContext.Artworks
                .Where(artwork => artworkIds.Contains(artwork.ArtworkId))
                .SumAsync(artwork => artwork.Price);
            return totalAmount;
        }

        public async Task<Artwork> CreateArtwork(Artwork artwork)
        {
            await _dbContext.AddAsync(artwork);
            await _dbContext.SaveChangesAsync();
            return artwork;
        }

        public async Task<bool> DeleteArtwork(int artworkId)
        {
            var artwork = await _dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkId == artworkId);
            if (artwork is null)
            {
                return false;

            }
            _dbContext.Remove(artwork);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Artwork?> GetArtwork(int artworkId)
        {
            var artwork = await _dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkId == artworkId);

            return artwork;
        }

        public async Task<IEnumerable<Artwork>> GetArtworkPredicate(Expression<Func<Artwork, bool>> predicate)
            => await _dbContext.Artworks.Where(predicate).ToListAsync();

        public async Task<IEnumerable<Artwork>> GetArtworksByArtistId(int artistId)
            => await _dbContext.Artworks.Where(a => a.ArtistID == artistId).ToListAsync();

        public async Task<bool> IsExistArtwork(int artworkId)
            => await _dbContext.Artworks.AnyAsync(a => a.ArtworkId == artworkId);

        public async Task<Artwork?> UpdateArtwork(Artwork artwork)
        {
            var artworkToUpdate = await _dbContext.Artworks
                .FirstOrDefaultAsync(a => a.ArtworkId == artwork.ArtworkId);
            if (artworkToUpdate is null)
            {
                return null;
            }

            artworkToUpdate.Name = artwork.Name;
            artworkToUpdate.Description = artwork.Description;
            artworkToUpdate.Image = artwork.Image;
            artworkToUpdate.Price = artwork.Price;
            artworkToUpdate.IsPublic = artwork.IsPublic;
            artworkToUpdate.IsBuyAvailable = artwork.IsBuyAvailable;
            await _dbContext.SaveChangesAsync();
            return artworkToUpdate;
        }

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

        public async Task<int> GetArtistIdByArtworkId(int artworkId)
        {
            return await _dbContext.Artworks
                .Where(a => a.ArtworkId == artworkId)
                .Select(a => a.ArtistID)
                .FirstOrDefaultAsync();
        }
    }
}
