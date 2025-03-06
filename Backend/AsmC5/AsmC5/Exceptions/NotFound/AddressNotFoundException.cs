using AsmC5.Exceptions.NotFound;

namespace AsmC5.Exceptions.NotFound
{
	public sealed class AddressNotFoundException : NotFoundException
	{
		public AddressNotFoundException(int addressId)
			: base($"Không tìm thấy địa chỉ với Id {addressId}") { }

        public AddressNotFoundException(string message) : base(message)
        {
            
        }
    }
}
