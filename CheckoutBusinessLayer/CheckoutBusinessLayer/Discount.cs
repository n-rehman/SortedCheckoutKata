namespace CheckoutBusinessLayer
{
	public class Discount : IDiscount
	{
		public string SKU { get; set; }
		public int Quantity { get; set; }
		public decimal Value { get; set; }
	}
}