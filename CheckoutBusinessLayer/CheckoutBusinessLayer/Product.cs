using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBusinessLayer
{
	public class Product : IProduct
	{
		public string SKU { get; set; }
		public decimal Price { get; set; }
	}
}
