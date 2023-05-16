using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Catagory()
        {
            Products = new List<Product>();
        }

    }
}
