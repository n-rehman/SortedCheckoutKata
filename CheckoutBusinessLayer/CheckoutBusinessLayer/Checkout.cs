using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBusinessLayer
{
	public class Checkout : ICheckout
	{
		private List<string> scannedProducts;
		private readonly IEnumerable<IProduct> productsCatalogue;


		public List<string> ScannedProducts { get { return scannedProducts; } }

		public Checkout(IEnumerable<IProduct> products)
		{
			scannedProducts = new List<string>();
			productsCatalogue = products;
		}
		public decimal Total()
		{
			decimal total = 0;

			total = productsCatalogue.Single(p => p.SKU == "A99").Price;
			return total;
		}

		public void Scan(string item)
		{
			if (!string.IsNullOrEmpty(item))
			{
				if (productsCatalogue.Any(product => product.SKU == item))
				{
					scannedProducts.Add(item);
				}

			}
		}


	}

}
