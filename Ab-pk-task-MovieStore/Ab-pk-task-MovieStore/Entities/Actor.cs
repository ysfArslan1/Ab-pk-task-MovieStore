using System.ComponentModel.DataAnnotations.Schema;

namespace Ab_pk_task_MovieStore.Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<MovieActor>? PlayedMovies { get; set; }
    }
}
