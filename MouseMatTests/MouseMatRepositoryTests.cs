using MouseMatLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMatTests
{
	[TestClass]
	public sealed class MouseMatRepositoryTests
	{
		[TestMethod]
		public void TestGet()
		{
			MouseMatRepository repo = new MouseMatRepository();
			MouseMat mat = new MouseMat("Razer", "Cloth", 20, 20, "Black", 80);

			List<MouseMat> mats = repo.Get().ToList();
			int countBefore = mats.Count;
			repo.Add(mat);
			List<MouseMat> mats2 = repo.Get().ToList();
			int countAfter = mats2.Count;

			Assert.AreEqual(countBefore + 1, countAfter);

		}

		[TestMethod]
		public void TestGetById()
		{
			MouseMatRepository repo = new MouseMatRepository();
			MouseMat mat = new MouseMat("Razer", "Cloth", 20, 20, "Black", 80);
			mat.Id = 1;

			MouseMat item = repo.GetById(1);

			Assert.AreEqual(item.Brand, mat.Brand);

		}

		[TestMethod]
		public void TestAdd()
		{
			MouseMatRepository repo = new MouseMatRepository();
			MouseMat mat = new MouseMat("Razer", "Cloth", 20, 20, "Black", 80);

			List<MouseMat> mats = repo.Get().ToList();
			int countBefore = repo.Count;
			MouseMat item = repo.Add(mat);
			List<MouseMat> mats2 = repo.Get().ToList();
			int countAfter = repo.Count;

			Assert.AreEqual(countBefore + 1, countAfter);
			
		}

		[TestMethod]
		public void TestDelete()
		{
			MouseMatRepository repo = new MouseMatRepository();
			MouseMat mat = new MouseMat("Razer", "Cloth", 20, 20, "Black", 80);
			mat.Id = 1;

			repo.Add(mat);
			List<MouseMat> mats = repo.Get().ToList();
			int countBefore = repo.Count;
			MouseMat item = repo.Delete(1);
			List<MouseMat> mats2 = repo.Get().ToList();
			int countAfter = repo.Count;

			Assert.AreEqual(countBefore, countAfter + 1);

		}

		[TestMethod]
		public void TestUpdate()
		{
			MouseMatRepository repo = new MouseMatRepository();
			MouseMat mat = new MouseMat("Razer", "Cloth", 20, 20, "Black", 80);
			mat.Id = 1;
			MouseMat update = new MouseMat("Steel Series", "Tempered Glass", 20, 20, "Gray", 95);

			MouseMat added = repo.Add(mat);
			MouseMat updated = repo.Update(1, update);

			Assert.AreEqual(update.Brand, updated.Brand);
			Assert.AreEqual(update.Material, updated.Material);
			Assert.AreEqual(update.Color, updated.Color);

		}
	}
}
