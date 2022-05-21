using RockStars.Domain.Entities.Songs;
using RockStars.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockStars.Domain.Entities.Artists
{
    public class Artist : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
            = new List<Song>();
    }
}
