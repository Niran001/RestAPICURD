using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICrud.Models
{
    public class Product
    {
        [Required]
       // public int Id { get; set; }
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
