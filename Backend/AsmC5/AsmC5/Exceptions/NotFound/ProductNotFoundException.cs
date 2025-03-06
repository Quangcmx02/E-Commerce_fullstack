using AsmC5.Exceptions.NotFound;

namespace AsmC5.Exceptions.NotFound
{
	public sealed class ProductNotFoundException : NotFoundException
	{
		public ProductNotFoundException(int productId)
			: base($"Không tìm thấy sản phẩm với Id: {productId} tồn tại trong cơ sở dữ liệu.")
		{
		}

		public ProductNotFoundException(string message) : base(message)
		{
		}
	}
}
