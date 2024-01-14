using System.ComponentModel.DataAnnotations.Schema;

namespace Ab_pk_task_MovieStore.Entities
{
    public class MovieActor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
