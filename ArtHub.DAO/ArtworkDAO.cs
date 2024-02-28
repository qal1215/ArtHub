﻿using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.DAO
{
    public class ArtworkDAO
    {
        private static ArtworkDAO instance = null;
        private readonly ArtHub2024DbContext dbContext = null;
        public ArtworkDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static ArtworkDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArtworkDAO();
                }
                return instance;
            }
        }

        public async Task<Artwork?> GetArtwork(int id)
        {
            return await dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkID == id);
        }

        public async Task<List<Artwork>> GetArtworksAsync()
        {
            return await dbContext.Artworks.ToListAsync();
        }

        public async Task AddArtworkAsync(Artwork artwork)
        {
            await dbContext.AddAsync(artwork);
            dbContext.SaveChanges();
        }

        public async Task<List<Artwork>> GetArtworksByArtistAsync(int artistID)
        {
            return await dbContext.Artworks.Where(a => a.ArtistID == artistID).ToListAsync();
        }

        public async Task<Artwork> UpdateArtWorkAsync(int id, Artwork artwork)
        {
            var artworkToUpdate = await dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkID == id);
            if (artworkToUpdate != null)
            {
                artworkToUpdate.ArtworkName = artwork.ArtworkName;
                artworkToUpdate.ArtworkDescription = artwork.ArtworkDescription;
                artworkToUpdate.ArtworkImage = artwork.ArtworkImage;
                artworkToUpdate.ArtworkPrice = artwork.ArtworkPrice;
                artworkToUpdate.IsPublic = artwork.IsPublic;
                artworkToUpdate.IsBuyAvailable = artwork.IsBuyAvailable;
                dbContext.SaveChanges();
            }
            return artworkToUpdate!;
        }

        public async Task<bool> IsExistArtwork(int id)
        {
            return await dbContext.Artworks.AnyAsync(a => a.ArtworkID == id);
        }

        public async Task DeleteArtworkAsync(int id)
        {
            var artwork = await dbContext.Artworks.FirstOrDefaultAsync(a => a.ArtworkID == id);
            if (artwork != null)
            {
                dbContext.Remove(artwork);
                dbContext.SaveChanges();
            }
        }
    }
}
