using Microsoft.EntityFrameworkCore;
using MouseMatLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMatTests
{
	[TestClass]
	[DoNotParallelize]
	public class MouseMatDbRepositoryTests
	{
		private const bool useDB = true;
		private static IMouseMatRepository _repo;

		[TestInitialize]
		public void init()
		{
			if (useDB)
			{
				var optionsBuilder = new DbContextOptionsBuilder<MannazRestAppDbContext>();
				optionsBuilder.UseSqlServer(SecretDB.ConnectStringSimply);
				MannazRestAppDbContext _dbContext = new(optionsBuilder.Options);
				_dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.MouseMats");
				_repo = new MouseMatRepositoryDB(_dbContext);
			}
			else
			{
				_repo = new MouseMatRepository();
			}
		}

		[TestMethod, Priority(1)]
		[DoNotParallelize]
		public void TestAddMouseMat()
		{
			MouseMat matRazer = _repo.Add(new MouseMat("Razer", "Cloth", 20, 20, "Black", 100));
			Assert.IsTrue(matRazer.Id > 0);
			IEnumerable<MouseMat> all = _repo.Get();
			Assert.AreEqual(1, all.Count());

			Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new MouseMat(null, "Cloth", 20, 20, "Black", 100)));
			Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new MouseMat("", "Cloth", 20, 20, "Black", 100)));
			Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new MouseMat("Razer", null, 20, 20, "Black", 100)));
			Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new MouseMat("Razer", "", 20, 20, "Black", 100)));
			Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 14, 20, "Black", 100)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 20, 14, "Black", 100)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 15, 15, "Black", 100)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 40, 40, "Black", 100)));
			Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 14, 20, null, 100)));
			Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 14, 20, "", 100)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 40, 40, "Black", -100)));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(new MouseMat("Razer", "Cloth", 40, 40, "Black", 0)));
		}

		[TestMethod, Priority(2)]
		[DoNotParallelize]
		public void TestGetMouseMat()
		{
			_repo.Add(new MouseMat("Razer", "Cloth", 20, 20, "Black", 100));
			
			IEnumerable<MouseMat> mouseMats = _repo.Get(sortBy: "brand");
			Assert.AreEqual(mouseMats.First().Brand, "Razer");

			mouseMats = _repo.Get(sortBy: "material");
			Assert.AreEqual(mouseMats.First().Material, "Cloth");

			mouseMats = _repo.Get(sortBy: "length");
			Assert.AreEqual(mouseMats.First().Length, 20);

			mouseMats = _repo.Get(sortBy: "width");
			Assert.AreEqual(mouseMats.First().Width, 20);

			mouseMats = _repo.Get(sortBy: "color");
			Assert.AreEqual(mouseMats.First().Color, "Black");

			mouseMats = _repo.Get(sortBy: "price");
			Assert.AreEqual(mouseMats.First().Price, 100);
		}

		[TestMethod, Priority(3)]
		[DoNotParallelize]
		public void TestUpdateMouseMat()
		{
			MouseMat mat = _repo.Add(new MouseMat("Razer", "Cloth", 20, 20, "Black", 100));
			MouseMat? update = _repo.Update(mat.Id, new MouseMat("Razer", "Cloth", 20, 35, "Gray", 150));
			Assert.IsNotNull(update);

			Assert.AreEqual(35, update.Width);
			MouseMat? mat2 = _repo.GetById(mat.Id);
			Assert.AreEqual("Gray", mat2.Color);

			Assert.IsNull(_repo.Update(-1, new MouseMat("Razer", "Cloth", 20, 20, "Black", 100)));
			Assert.ThrowsException<ArgumentNullException>(() => _repo.Update(mat.Id, new MouseMat("", "Cloth", 20, 20, "Gray", 100)));

		}

		[TestMethod, Priority(4)]
		[DoNotParallelize]
		public void TestDeleteMouseMat()
		{

		}
	}
}
