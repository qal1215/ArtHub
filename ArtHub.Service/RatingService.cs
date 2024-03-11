using ArtHub.BusinessObject;
using ArtHub.DTO.RatingDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service;

public class RatingService : IRatingService
{
    private readonly IMapper _mapper;
    private readonly IRatingRepository _ratingRepository;
    private readonly IArtworkRepository _artworkRepository;

    public RatingService(IMapper mapper, IRatingRepository ratingRepository, IArtworkRepository artworkRepository)
    {
        _mapper = mapper;
        _ratingRepository = ratingRepository;
        _artworkRepository = artworkRepository;
    }

    public async Task<bool> AddOrUpdatingRatingForArtwork(PostRating postRating)
    {
        var artwork = await _artworkRepository.GetArtwork(postRating.ArtworkId);
        if (artwork is null) return false;

        var userHasRatingArtwork = await _ratingRepository.GetRatingByArtworkIdNUserId(postRating.ArtworkId, postRating.UserId);

        if (userHasRatingArtwork is null)
        {
            var rating = _mapper.Map<Rating>(postRating);
            await _ratingRepository.AddRatingForArtwork(rating);
        }
        else if (userHasRatingArtwork is not null && userHasRatingArtwork.Rate != postRating.Rating)
        {
            userHasRatingArtwork.Rate = postRating.Rating;
            await _ratingRepository.UpdateRatingForArtwork(userHasRatingArtwork);
        }

        var ratings = await _ratingRepository.GetRatingsByArtworkId(postRating.ArtworkId);
        var avgRating = ratings.Average(r => r.Rate);
        artwork.ArtworkRating = (float)(ratings.Count > 0 ? avgRating : 0);
        return (await _artworkRepository.UpdateArtwork(artwork)) is not null;
    }

    public async Task<bool> UnRatingForArtwork(PostRating postRating)
    {
        var artwork = await _artworkRepository.GetArtwork(postRating.ArtworkId);
        if (artwork is null) return false;
        var userHasRatingArtwork = await _ratingRepository.GetRatingByArtworkIdNUserId(postRating.ArtworkId, postRating.UserId);
        if (userHasRatingArtwork is null) return false;
        await _ratingRepository.UnRatingArtwork(userHasRatingArtwork);

        var ratings = await _ratingRepository.GetRatingsByArtworkId(postRating.ArtworkId);
        var avgRating = ratings.Average(r => r.Rate);
        artwork.ArtworkRating = (float)(ratings.Count > 0 ? avgRating : 0);
        return (await _artworkRepository.UpdateArtwork(artwork)) is not null;
    }
}

