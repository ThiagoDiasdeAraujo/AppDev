namespace DemoApp.Models
{
	public class Product
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }


		public Product(int iD, string name, double price)
		{
			ID = iD;
			Name = name;
			Price = price;
		}
	}
}
