using System.ComponentModel.DataAnnotations.Schema;

namespace Ab_pk_task_MovieStore.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustemerId { get; set; }
        public virtual Customer Custemer { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int Prize { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool isActive { get; set; } = true;
    }
}
