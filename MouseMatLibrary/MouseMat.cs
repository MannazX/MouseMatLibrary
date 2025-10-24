namespace MouseMatLibrary
{
	public class MouseMat
	{
		#region Properties
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Material { get; set; }
		public double Length { get; set; }
		public double Width { get; set; }
		public string Color { get; set; }
		public double Price { get; set; }
		#endregion

		#region
		public MouseMat(string brand, string material, double length, double width, string color, double price)
		{
			if (string.IsNullOrEmpty(brand))
			{
				throw new ArgumentNullException("The brand name cannot be null or empty");
			}
			if (string.IsNullOrEmpty(material))
			{
				throw new ArgumentNullException("The material cannot be null or empty");
			}
			if (length < 15 || width < 15)
			{
				throw new ArgumentOutOfRangeException("The length or width cannot be less than 15 cm");
			}
			if (length * width < 400 || length * width > 1225)
			{
				throw new ArgumentOutOfRangeException("The length and width determine an area outside of the permitted size");
			}
			if (string.IsNullOrEmpty(color))
			{
				throw new ArgumentNullException("The color cannto be null or empty");
			}
			if (price == null)
			{
				throw new ArgumentNullException("The price cannot be null");
			}
			Brand = brand;
			Material = material;
			Length = length;
			Width = width;
			Color = color;
			Price = price;
		}
		#endregion

		#region Methods
		public override string ToString()
		{
			return $"Brand: {Brand}, Material: {Material}, Length: {Length}, Width: {Width}, Color: {Color}, Price: {Price}";
		}
		#endregion
	}
}
