using System;
using System.Collections.Generic;
using CheckoutBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutUnitTests
{
	[TestClass]
	public class CheckoutBLUnitTests
	{
		private ICheckout checkout;
		public CheckoutBLUnitTests()
		{
			IEnumerable<Product> products = new[]
			{
				new Product{SKU = "A99", Price = 0.50m},
				new Product{SKU = "B15", Price = 0.30m},
				new Product{SKU = "C40", Price = 0.60m}
			};

			

			checkout = new Checkout(products);
		}
		
		[TestMethod]
		public void scan_SingleProduct()
		{
			//arrange 
			ICheckout iCheckout = checkout;
			

			//act
			iCheckout.Scan("A99");
			//assert
			Assert.AreEqual("A99", iCheckout.ScannedProducts.FindLast(p => p=="A99"));

		}
	}
}
