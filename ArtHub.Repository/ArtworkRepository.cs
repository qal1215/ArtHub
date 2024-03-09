using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.DAO.ModelResult;
using ArtHub.Repository.Contracts;
using System.Linq.Expressions;

namespace ArtHub.Repository
{
    public class ArtworkRepository : IArtworkRepository
    {
        public async Task<Artwork> CreateArtwork(Artwork artwork) => await ArtworkDAO.Instance.AddArtworkAsync(artwork);

        public async Task<bool> DeleteArtwork(int id)
        {
            var isExist = await ArtworkDAO.Instance.IsExistArtwork(id);
            if (!isExist)
            {
                return false;
            }

            await ArtworkDAO.Instance.DeleteArtworkAsync(id);
            return true;
        }

        public async Task<Artwork?> GetArtwork(int id)
        {
            var isExist = await ArtworkDAO.Instance.IsExistArtwork(id);
            if (!isExist)
            {
                return null;
            }

            return await ArtworkDAO.Instance.GetArtwork(id);
        }

        public async Task<IEnumerable<Artwork>> GetArtworkPredicate(Expression<Func<Artwork, bool>> predicate)
        {
            return await ArtworkDAO.Instance.GetArtworks(predicate);
        }

        public async Task<IEnumerable<Artwork>> GetArtworksByArtistId(int artistId) => await ArtworkDAO.Instance.GetArtworksByArtistAsync(artistId);

        public async Task<bool> IsExistArtwork(int id) => await ArtworkDAO.Instance.IsExistArtwork(id);

        public async Task<Artwork?> UpdateArtwork(Artwork artwork)
        {
            var isExist = await ArtworkDAO.Instance.IsExistArtwork(artwork.ArtworkId);
            if (!isExist)
            {
                return null;
            }

            var updateTo = await ArtworkDAO.Instance.UpdateArtWorkAsync(artwork.ArtworkId, artwork);

            return updateTo;
        }

        public async Task<PagedResult<Artwork>> GetArtworksPaging(int page, int pageSize, string? q)
        {
            return await ArtworkDAO.Instance.GetArtworksPaging(page, pageSize, q);
        }

        public async Task<bool> ReportArtwork(int artworkId)
        {
            return await ArtworkDAO.Instance.ReportArtwork(artworkId);
        }
    }
}
