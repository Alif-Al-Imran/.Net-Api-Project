using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CatProDTO : CatagoryDTO
    {
        public List<ProductDTO> Products { get; set; }
        public CatProDTO()
        {
            Products = new List<ProductDTO>();
        }
    }
}
