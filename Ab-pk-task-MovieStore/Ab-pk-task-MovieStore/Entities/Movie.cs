using System.ComponentModel.DataAnnotations.Schema;

namespace Ab_pk_task_MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int DirectorId { get; set; } 
        public virtual Director Director { get; set; } 
        public virtual ICollection<MovieActor>? Actors { get; set;}//düzenlenecek
        public int Prize { get; set; }
    }
}
