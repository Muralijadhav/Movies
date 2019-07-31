using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Models
{
    public class MovieActor
    {
        [Key, Column(Order = 0)]
        public int Movie_MovieId { get; set; }

        [Key, Column(Order = 1)]
        public int Actor_ActorId { get; set; }
    }
}