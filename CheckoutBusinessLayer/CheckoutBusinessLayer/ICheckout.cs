using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutBusinessLayer
{
	public interface ICheckout
	{
		void Scan(string scan);
		decimal Total();
		List<string> ScannedProducts { get; }
	}
}
