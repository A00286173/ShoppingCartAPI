﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ShoppingCarts
    {
        public int Id { get; set; } // Primary Key
        public string? User { get; set; }
        public List<Product> Products { get; set; } = new List<Product>(); //List of products
    }
}
