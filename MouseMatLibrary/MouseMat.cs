namespace MouseMatLibrary
{
	public class MouseMat
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Material { get; set; }
		public double Length { get; set; }
		public double Width { get; set; }
		public string Color { get; set; }
		public double Price { get; set; }

		public MouseMat(string brand, string material, double length, double width, string color, double price)
		{
			// Include Exceptions here
			Brand = brand;
			Material = material;
			Length = length;
			Width = width;
			Color = color;
			Price = price;
		}

		public override string ToString()
		{
			return $"Brand: {Brand}, Material: {Material}, Length: {Length}, Width: {Width}, Color: {Color}, Price: {Price}";
		}
	}
}
