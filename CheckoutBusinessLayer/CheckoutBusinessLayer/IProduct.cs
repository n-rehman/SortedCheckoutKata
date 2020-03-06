using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBusinessLayer
{
	public interface IProduct
	{
		string SKU { get; set; }
		decimal Price { get; set; }
	}
}
