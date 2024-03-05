using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GenreId { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<Artwork>? Artwork { get; set; }
    }
}
