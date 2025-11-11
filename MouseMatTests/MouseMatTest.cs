using MouseMatLibrary;

namespace MouseMatTests
{
	[TestClass]
	public sealed class MouseMatTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestBrand()
		{
			MouseMat mat = new MouseMat("", "Cloth", 20, 20, "Black", 80);
			MouseMat mat2 = new MouseMat(null, "Cloth", 20, 20, "Black", 80);
			MouseMat mat3 = new MouseMat("Razer", "Cloth", 20, 20, "Black", 80);

			Assert.ThrowsException<ArgumentNullException>(() => mat);
			Assert.ThrowsException<ArgumentNullException>(() => mat2);
			Assert.AreEqual(mat3.Brand, "Razer");

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestMaterial()
		{
			MouseMat mat = new MouseMat("Razer", "", 20, 20, "Black", 80);
			MouseMat mat2 = new MouseMat("Razer", null, 20, 20, "Black", 80);
			MouseMat mat3 = new MouseMat("Razer", "Cloth", 20, 20, "Black", 80);

			Assert.ThrowsException<ArgumentNullException>(() => mat);
			Assert.ThrowsException<ArgumentNullException>(() => mat2);
			Assert.AreEqual(mat3.Material, "Cloth");

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestLength()
		{
			MouseMat mat = new MouseMat("Steel Series", "Cloth", 13, 32, "Gray", 100);
			MouseMat mat2 = new MouseMat("Steel Series", "Cloth", 15, 35, "Gray", 100);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => mat);
			Assert.AreEqual(mat2.Length, 15);

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestWidth()
		{
			MouseMat mat = new MouseMat("Corsair", "Cloth", 32, 13, "Black", 75);
			MouseMat mat2 = new MouseMat("Corsair", "Cloth", 35, 15, "Black", 75);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => mat);
			Assert.AreEqual(mat2.Width, 15);

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestArea()
		{
			MouseMat mat = new MouseMat("Razer", "Tempered Glass", 18, 18, "Black", 90);
			MouseMat mat2 = new MouseMat("Razer", "Tempered Glass", 37, 37, "Black", 90);
			MouseMat mat3 = new MouseMat("Razer", "Tempered Glass", 20, 20, "Black", 90);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => mat);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => mat2);
			Assert.AreEqual(mat3.Length * mat3.Width, 400);

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestColor()
		{
			MouseMat mat = new MouseMat("Corsair", "Cloth", 20, 20, "", 85);
			MouseMat mat2 = new MouseMat("Corsair", "Cloth", 20, 20, null, 85);
			MouseMat mat3 = new MouseMat("Corsair", "Cloth", 20, 20, "Black", 85);

			Assert.ThrowsException<ArgumentNullException>(() => mat);
			Assert.ThrowsException<ArgumentNullException>(() => mat2);
			Assert.AreEqual(mat3.Color, "Black");

		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestPrice()
		{
			MouseMat mat = new MouseMat("Steel Series", "Tempered Glass", 20, 20, "Gray", 0);
			MouseMat mat2 = new MouseMat("Steel Series", "Tempered Glass", 20, 20, "Gray", -20);
			MouseMat mat3 = new MouseMat("Steel Series", "Tempered Glass", 20, 20, "Gray", 100);

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => mat);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => mat2);
			Assert.AreEqual(mat3.Price, 100);

		}
	}
}
