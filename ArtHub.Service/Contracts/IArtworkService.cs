using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;

namespace ArtHub.Service.Contracts
{
    public interface IArtworkService
    {
        public Task<Artwork?> GetArtworkById(int id);

        public Task<IEnumerable<Artwork>> GetArtworksByArtistId(int artistId);

        public Task<IEnumerable<Artwork>> GetArtworksByTitle(string title);

        public Task<Artwork?> UpdateArtwork(Artwork artwork);

        public Task<Artwork> CreateArtwork(Artwork artwork);

        public Task<bool> DeleteArtwork(int id);

        public Task<PagedResult<Artwork>> GetArtworksPaging(QueryPaging queryPaging);
    }
}
