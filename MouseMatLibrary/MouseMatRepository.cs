using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseMatLibrary
{
	public class MouseMatRepository : IMouseMatRepository
	{
		#region Repository Setup
		private static List<MouseMat> _mouseMats;

		public int Count { get { return _mouseMats.Count; } }

		public MouseMatRepository()
		{
			_mouseMats = new List<MouseMat>();
		}
		#endregion

		#region Repository Methods
		public IEnumerable<MouseMat> Get(string? brand = null, string? material = null, double? length = null, double? width = null, string? color = null, double? price = null, string? sortBy = null)
		{
			if (brand != null)
			{
				_mouseMats = _mouseMats.Where(x => x.Brand != null && x.Brand.StartsWith(brand, StringComparison.OrdinalIgnoreCase)).ToList();
			}
			if (material != null)
			{
				_mouseMats = _mouseMats.Where(x => x.Material != null && x.Material.StartsWith(material, StringComparison.OrdinalIgnoreCase)).ToList();
			}
			if (color != null)
			{
				_mouseMats = _mouseMats.Where(x => x.Color != null && x.Color.StartsWith(color, StringComparison.OrdinalIgnoreCase)).ToList();
			}
			if (price != null)
			{
				_mouseMats = _mouseMats.Where(x => x.Price <= price).ToList();
			}
			if (sortBy != null)
			{
				if (sortBy.Equals("length", StringComparison.OrdinalIgnoreCase))
				{
					_mouseMats = _mouseMats.OrderBy(x => x.Length).ToList();
				}
				else if (sortBy.Equals("width", StringComparison.OrdinalIgnoreCase))
				{
					_mouseMats = _mouseMats.OrderBy(x => x.Width).ToList();
				}
				else if (sortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
				{
					_mouseMats = _mouseMats.OrderBy(x => x.Price).ToList();
				}
			}
			return _mouseMats;
		}

		public MouseMat GetById(int id)
		{
			MouseMat item = null;
			foreach (MouseMat mat in _mouseMats)
			{
				if (mat.Id == id)
				{
					item = mat;
				}
			}
			return item;
		}

		public MouseMat Add(MouseMat mouseMat)
		{
			_mouseMats.Add(mouseMat);
			return mouseMat;
		}

		public MouseMat Delete(int id)
		{
			MouseMat item = GetById(id);
			if (item != null)
			{
				_mouseMats.Remove(item);
				return item;
			}
			return null;
		}

		public MouseMat Update(int id, MouseMat update)
		{
			MouseMat item = GetById(id);
			if (item != null)
			{
				item.Brand = update.Brand;
				item.Material = update.Material;
				item.Length = update.Length;
				item.Width = update.Width;
				item.Color = update.Color;
				item.Price = update.Price;
			}
			_mouseMats[_mouseMats.IndexOf(item)] = item;
			return item;
		}
		#endregion
	}
}
