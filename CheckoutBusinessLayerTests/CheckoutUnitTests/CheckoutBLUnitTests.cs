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

			IEnumerable<IDiscount> discount = new[]
			{
				new Discount{SKU = "A99", Quantity = 3, Value = 0.20m},
				new Discount{SKU = "B15", Quantity = 2, Value = 0.15m},
			};

			checkout = new Checkout(products, discount);
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
		[TestMethod]
		public void Single_A99_Cost_50P()
		{
			//arrange 
			ICheckout iCheckout = checkout;


			//act
			iCheckout.Scan("A99");
			
			
			//assert
			Assert.AreEqual(0.50M, iCheckout.Total());

		}
		[TestMethod]
		public void Three_Different_Items_Cost_140P()
		{
			//arrange 
			ICheckout iCheckout = checkout;


			//act
			iCheckout.Scan("A99");
			iCheckout.Scan("B15");
			iCheckout.Scan("C40");
			//assert
			Assert.AreEqual(1.40M, iCheckout.Total());

		}
		[TestMethod]
		public void Three_A999_Items_Gets20PDiscount()
		{
			//arrange 
			ICheckout iCheckout = checkout;


			//act
			iCheckout.Scan("A99");
			iCheckout.Scan("A99");
			iCheckout.Scan("A99");
			//assert
			Assert.AreEqual(1.30M, iCheckout.Total());

		}
		[TestMethod]
		public void Two_B15_Items_Get15PDiscount()
		{
			//arrange 
			ICheckout iCheckout = checkout;


			//act
			iCheckout.Scan("B15");
			iCheckout.Scan("B15");
			
			//assert
			Assert.AreEqual(0.45m, iCheckout.Total());

		}
		[TestMethod]
		public void verify_multi_discount_combinations()
		{
			//arrange 
			ICheckout iCheckout = checkout;


			//act
			iCheckout.Scan("B15");//0.30
			iCheckout.Scan("A99");//0.50
			iCheckout.Scan("A99");//0.50			
			iCheckout.Scan("B15");//0.30		
			iCheckout.Scan("C40");//0.60
			iCheckout.Scan("C40");//0.60
			iCheckout.Scan("C40");//0.60
			iCheckout.Scan("A99");//0.50


			var total = checkout.Total();
			//assert
			//3As = 1.5 - 0.2= 1.30
			//2Bs = 0.60 -15 = 0.45
			//3Cs = 1.8 - 0 =1.8
			
			Assert.AreEqual(3.55m, total);

		}
	}
}
