using Azure.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMatLibrary
{
	public class MouseMatRepositoryDB : IMouseMatRepository
	{
		private readonly MannazRestAppDbContext _context;
		public MouseMatRepositoryDB(MannazRestAppDbContext dbContext)
		{
			_context = dbContext;
		}

		public MouseMat Add(MouseMat mouseMat)
		{
			mouseMat.Id = 0;
			_context.MouseMats.Add(mouseMat);
			_context.SaveChanges();
			return mouseMat;
		}

		public MouseMat Delete(int id)
		{
			MouseMat? mouseMat = GetById(id);
			if (mouseMat == null)
			{
				return null;
			}
			_context.MouseMats.Remove(mouseMat);
			_context.SaveChanges();
			return mouseMat;
		}

		public IEnumerable<MouseMat> Get(string? brand = null, string? material = null, double? length = null, double? width = null, string? color = null, double? price = null, string? sortBy = null)
		{
			IQueryable<MouseMat> query = _context.MouseMats.ToList().AsQueryable();
			if (brand != null)
			{
				query = query.Where(x => x.Brand.StartsWith(brand));
			}
			if (material != null)
			{
				query = query.Where(x => x.Material.StartsWith(material));
			}
			if (color != null)
			{
				query = query.Where(x => x.Color.StartsWith(color));
			}
			if (price != null)
			{
				query = query.Where(x => x.Price <= price);
			}
			if (sortBy != null)
			{
				sortBy = sortBy.ToLower();
				switch (sortBy)
				{
					case "brand":
					case "brand_asc":
						query = query.OrderBy(x => x.Brand);
						break;
					case "material":
					case "material_asc":
						query = query.OrderBy(x => x.Material);
						break;
					case "length":
					case "length_asc":
						query = query.OrderBy(x => x.Length);
						break;
					case "width":
					case "width_asc":
						query = query.OrderBy(x => x.Width);
						break;
					case "color":
					case "color_asc":
						query = query.OrderBy(x => x.Color);
						break;
					case "price":
					case "price_asc":
						query = query.OrderBy(x => x.Price);
						break;
				}
			}
			return query;
		}

		public MouseMat GetById(int id)
		{
			return _context.MouseMats.FirstOrDefault(x => x.Id == id);
		}

		public MouseMat Update(int id, MouseMat update)
		{
			MouseMat? mouseMat = GetById(id);
			if (mouseMat == null)
			{
				return null;
			}
			mouseMat.Brand = update.Brand;
			mouseMat.Material = update.Material;
			mouseMat.Length = update.Length;
			mouseMat.Width = update.Width;
			mouseMat.Color = update.Color;
			mouseMat.Price = update.Price;
			_context.SaveChanges();
			return mouseMat;
		}
	}
}
