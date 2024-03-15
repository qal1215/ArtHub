using ArtHub.BusinessObject;
using ArtHub.DTO.ArtworkDTO;
using ArtHub.DTO.ModelResult;

namespace ArtHub.Service.Contracts
{
    public interface IArtworkService
    {
        Task<ViewArtwork?> GetArtworkById(int id);

        Task<IEnumerable<ViewArtwork>> GetArtworksByArtistId(int artistId);

        Task<IEnumerable<Artwork>> GetArtworksByTitle(string title);

        Task<Artwork?> UpdateArtwork(UpdateArtwork artwork);

        Task<ViewArtwork> CreateArtwork(CreateArtwork artwork);

        Task<bool> DeleteArtwork(int id);

        Task<PagedResult<ViewArtwork>> GetArtworksPaging(QueryPaging queryPaging);
        Task<IEnumerable<ViewArtwork>?> GetArtworksByOwnerId(int userId);
    }
}
