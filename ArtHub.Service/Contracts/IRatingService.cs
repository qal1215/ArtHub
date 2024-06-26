﻿using ArtHub.DTO.RatingDTO;

namespace ArtHub.Service.Contracts;
public interface IRatingService
{
    Task<bool> AddOrUpdatingRatingForArtwork(PostRating postRating);

    Task<bool> UnRatingForArtwork(PostRating rating);
}
