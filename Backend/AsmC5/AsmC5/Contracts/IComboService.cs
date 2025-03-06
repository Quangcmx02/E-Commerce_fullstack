using AsmC5.Common.Request;
using AsmC5.DTOs.ComboDtos;

namespace AsmC5.Interfaces
{
    public interface IComboService
    {
        Task<(IEnumerable<ComboDto> comboDtos, MetaData metaData)> GetAllComboAsync(ComboRequestParameters comboRequestParameters);
        Task<ComboDto> GetComboByIdAsync(int id);
        Task<ComboDto> CreateComboAsync(ComboForCreateDto comboDto);
        Task<ComboDto> UpdateComboAsync(int comboId, ComboForUpdateDto productDto);
        Task DeleteProductAsync(int productId);
    }
}