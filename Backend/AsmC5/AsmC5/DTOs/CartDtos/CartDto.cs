using AsmC5.DTOs.CartItemDtos;

namespace AsmC5.DTOs.CartDtos;

using Models; 

public class CartDto
{
    public int CartID { get; set; }
    public string? SessionId { get; set; }
    public string? UserId { get; set; }
    public ICollection<CartItemDto> CartItems { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}