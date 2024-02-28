using ArtHub.BusinessObject;
using ArtHub.Repository;

namespace ArtHub.Service.ArtworkService
{
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository _artworkRepository;

        public ArtworkService()
        {
            _artworkRepository = new ArtworkRepository();
        }

        public async Task<Artwork> CreateArtwork(Artwork artwork)
        {
            artwork.ArtworkDate = DateTime.Now;
            artwork.ArtworkRating = 0;
            return await _artworkRepository.CreateArtwork(artwork);
        }

        public async Task<bool> DeleteArtwork(int id)
        {
            var isExist = await _artworkRepository.IsExistArtwork(id);
            if (!isExist)
            {
                return false;
            }
            return await _artworkRepository.DeleteArtwork(id);
        }

        public async Task<Artwork?> GetArtworkById(int id)
        {
            return await _artworkRepository.GetArtwork(id);
        }

        public async Task<IEnumerable<Artwork>> GetArtworksByArtistId(int artistId)
        {
            return await _artworkRepository.GetArtworksByArtistId(artistId);
        }

        public async Task<IEnumerable<Artwork>> GetArtworksByTitle(string title)
        {
            return await _artworkRepository.GetArtworkPredicate(a => a.Name.Contains(title));
        }

        public async Task<Artwork?> UpdateArtwork(Artwork artwork)
        {
            var isExist = await _artworkRepository.IsExistArtwork(artwork.ArtworkID);
            if (!isExist)
            {
                return null;
            }

            return await _artworkRepository.UpdateArtwork(artwork);
        }
    }
}
