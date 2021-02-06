using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Models
{
   public class Produto : BaseEntity
    {
        public string name { get; set; }
        public string description { get; set; }
        public double value { get; set; }
        public string brand { get; set; }
        public virtual Categoria categoria { get; set; }
        
        [NotMapped]
        public int CategoryId { get; set; }
    }
}
