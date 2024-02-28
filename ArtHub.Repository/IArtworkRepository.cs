using ArtHub.BusinessObject;
using System.Linq.Expressions;

namespace ArtHub.Repository
{
    public interface IArtworkRepository
    {
        public Task<Artwork> CreateArtwork(Artwork artwork);

        public Task<Artwork?> GetArtwork(int id);

        public Task<IEnumerable<Artwork>> GetArtworksByArtistId(int artistId);

        public Task<Artwork?> UpdateArtwork(Artwork artwork);

        public Task<bool> DeleteArtwork(int id);

        public Task<bool> IsExistArtwork(int id);

        public Task<IEnumerable<Artwork>> GetArtworkPredicate(Expression<Func<Artwork, bool>> predicate);
    }
}
