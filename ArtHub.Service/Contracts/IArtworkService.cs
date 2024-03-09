using ArtHub.BusinessObject;
using ArtHub.DAO.ArtworkDTO;
using ArtHub.DAO.ModelResult;

namespace ArtHub.Service.Contracts
{
    public interface IArtworkService
    {
        public Task<Artwork?> GetArtworkById(int id);

        public Task<IEnumerable<Artwork>> GetArtworksByArtistId(int artistId);

        public Task<IEnumerable<Artwork>> GetArtworksByTitle(string title);

        public Task<Artwork?> UpdateArtwork(Artwork artwork);

        public Task<Artwork> CreateArtwork(CreateArtwork artwork);

        public Task<bool> DeleteArtwork(int id);

        public Task<PagedResult<Artwork>> GetArtworksPaging(QueryPaging queryPaging);

        public Task<bool> ReportArtwork(int artworkId);
    }
}
