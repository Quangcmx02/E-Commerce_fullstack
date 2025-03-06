using AsmC5.Exceptions.NotFound;

namespace AsmC5.Exceptions.NotFound
{
	public sealed class CartItemNotFoundException : NotFoundException
	{
		public CartItemNotFoundException(int cartItemId) : base($"Không tìm thấy sản phẩm trong giỏ hàng với Id {cartItemId}")
		{
		}

        public CartItemNotFoundException(string message): base(message)
        {
            
        }
    }
}
