using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [ForeignKey("User")]
        public string UId { get; set; }
        public  virtual User User { get; set; }

    }
}
