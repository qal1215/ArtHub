using ArtHub.BusinessObject;
using ArtHub.DTO.ArtworkDTO;
using ArtHub.DTO.ModelResult;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using ArtHub.Service.Helper;
using AutoMapper;

namespace ArtHub.Service
{
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository _artworkRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public ArtworkService(IMapper mapper, IArtworkRepository artworkRepository, IGenreRepository genreRepository, IOrderRepository orderRepository, IAccountRepository accountRepository)
        {
            _artworkRepository = artworkRepository;
            _genreRepository = genreRepository;
            _orderRepository = orderRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<ViewArtwork> CreateArtwork(CreateArtwork creating)
        {
            var genre = await _genreRepository.SearchGenreByName(creating.GenreName);
            if (genre is null)
            {
                genre = await _genreRepository.AddGenre(creating.GenreName);
            }
            Artwork artwork = _mapper.Map<Artwork>(creating);
            artwork.ArtworkDate = DateTime.Now;
            artwork.ArtworkRating = 0;
            artwork.GenreId = genre.GenreId;
            var result = await _artworkRepository.CreateArtwork(artwork);

            var viewArtwork = _mapper.Map<ViewArtwork>(result);
            viewArtwork.GenreName = result.Genre.Name;

            return viewArtwork;
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

        public async Task<ViewArtwork?> GetArtworkById(int id)
        {
            var artwork = await _artworkRepository.GetArtwork(id);
            if (artwork is null) return null;

            var viewArtwork = _mapper.Map<ViewArtwork>(artwork);
            viewArtwork.MembersRated = await _artworkRepository.GetMembersRated(id);
            return viewArtwork;
        }

        public async Task<IEnumerable<ViewArtwork>> GetArtworksByArtistId(int artistId)
        {
            var artworks = await _artworkRepository.GetArtworksByArtistId(artistId);
            var viewArtworks = _mapper.Map<List<ViewArtwork>>(artworks);
            foreach (ViewArtwork v in viewArtworks)
            {
                v.MembersRated = await _artworkRepository.GetMembersRated(v.ArtworkId);
            }

            return viewArtworks;
        }

        public async Task<IEnumerable<Artwork>> GetArtworksByTitle(string title)
        {
            return await _artworkRepository.GetArtworkPredicate(a => a.Name.Contains(title));
        }

        public async Task<IEnumerable<Artwork>> GetArtworksByPulish()
        {
            return await _artworkRepository.GetArtworkPredicate(a => a.IsPublic == true);
        }

        public async Task<Artwork?> UpdateArtwork(UpdateArtwork updateArtwork)
        {
            var artwork = _mapper.Map<Artwork>(updateArtwork);
            var isExist = await _artworkRepository.IsExistArtwork(artwork.ArtworkId);
            if (!isExist)
            {
                return null;
            }

            return await _artworkRepository.UpdateArtwork(artwork);
        }

        public async Task<PagedResult<ViewArtwork>> GetArtworksPaging(QueryPaging queryPaging)
        {
            queryPaging = queryPaging.CheckQueryPaging();
            var paged = await _artworkRepository.GetArtworksPaging(queryPaging.Page, queryPaging.PageSize, queryPaging.Query);
            var items = _mapper.Map<List<ViewArtwork>>(paged.Items);
            foreach (ViewArtwork artwork in items)
            {
                artwork.MembersRated = await _artworkRepository.GetMembersRated(artwork.ArtworkId);
            }

            return new PagedResult<ViewArtwork>
            {
                Page = paged.Page,
                PageSize = paged.PageSize,
                TotalItems = paged.TotalItems,
                TotalPages = paged.TotalPages,
                Items = items
            };
        }

        public async Task<IEnumerable<ViewArtwork>?> GetArtworksByOwnerId(int ownerId)
        {
            var isOwnerExist = await _accountRepository.IsExistedAccount(ownerId);
            if (!isOwnerExist) return null;
            var artworkIdsOwner = await _orderRepository.GetArtworkIdByOwnerId(ownerId);
            var listArtwork = await _artworkRepository.GetArtworkPredicate(a => artworkIdsOwner.Contains(a.ArtworkId));
            return _mapper.Map<List<ViewArtwork>>(listArtwork);
        }
    }
}
