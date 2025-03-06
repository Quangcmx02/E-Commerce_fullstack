using AsmC5.Common.Request;
using AsmC5.Models;

namespace AsmC5.Interfaces
{
    public interface IComboRepository : IRepositoryBase<Combo>
    {
        Task<Combo?> GetComboByIdWithDetailsAsync(int id);
        Task<PagedList<Combo>> GetComboWithDetailsAsync(ComboRequestParameters comboRequestParameters);
        Task<bool> ComboNameExistsAsync(string name);
        Task<bool> ComboExistsAsync(int id);
    }
}
