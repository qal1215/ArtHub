using ArtHub.BusinessObject;
using ArtHub.DTO.ArtworkDTO;
using ArtHub.DTO.ModelResult;

namespace ArtHub.Service.Contracts
{
    public interface IArtworkService
    {
        public Task<ViewArtwork?> GetArtworkById(int id);

        public Task<IEnumerable<ViewArtwork>> GetArtworksByArtistId(int artistId);

        public Task<IEnumerable<Artwork>> GetArtworksByTitle(string title);

        public Task<Artwork?> UpdateArtwork(UpdateArtwork artwork);

        public Task<ViewArtwork> CreateArtwork(CreateArtwork artwork);

        public Task<bool> DeleteArtwork(int id);

        public Task<PagedResult<ViewArtwork>> GetArtworksPaging(QueryPaging queryPaging);
    }
}
