using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Clothing_Api.Data.Entities
{
    public class ProductEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public long Price { get; set; }
        public string ImageURL { get; set; } 
    }
}
