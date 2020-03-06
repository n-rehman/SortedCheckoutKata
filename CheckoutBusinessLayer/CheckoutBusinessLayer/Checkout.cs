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
		private readonly IEnumerable<IDiscount> _discounts;


		public List<string> ScannedProducts { get { return scannedProducts; } }

		public Checkout(IEnumerable<IProduct> products, IEnumerable<IDiscount> discounts)
		{
			scannedProducts = new List<string>();
			productsCatalogue = products;
			_discounts = discounts;
		}
		public decimal Total()
		{
			decimal total = 0;
			decimal discount = 0;
			total = getTotal(total);
			discount = getDiscount(discount);

			return total - discount;
		}

		private decimal getDiscount(decimal discount)
		{
			foreach (var disc in _discounts)
			{
				//check if any prod qualify discount
				if (scannedProducts.Count(basket => basket == disc.SKU) == disc.Quantity)
					discount += disc.Value;


			}
			
			return discount;
		}

		private decimal getTotal(decimal total)
		{
			foreach (var prod in scannedProducts)
			{
				total += productsCatalogue.Single(p => p.SKU == prod).Price;
			}

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
