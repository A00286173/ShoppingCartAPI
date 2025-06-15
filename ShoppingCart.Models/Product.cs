using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } // Number of product (Optional)

        public int CategoryId { get; set; } //Foreign Key <Category>
        public string? Category { get; set; } // Category property to the product model

    }
}
