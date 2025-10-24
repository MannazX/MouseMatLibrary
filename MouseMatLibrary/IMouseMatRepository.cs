
namespace MouseMatLibrary
{
	public interface IMouseMatRepository
	{
		MouseMat Add(MouseMat mouseMat);
		MouseMat Delete(int id);
		IEnumerable<MouseMat> Get(string? brand = null, string? material = null, double? length = null, double? width = null, string? color = null, double? price = null, string? sortBy = null);
		MouseMat GetById(int id);
		MouseMat Update(int id, MouseMat update);
	}
}