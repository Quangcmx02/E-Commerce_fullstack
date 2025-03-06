using AsmC5.Common.Request;
using AsmC5.Models;

namespace AsmC5.Interfaces
{
    public interface IUserRepository :IRepositoryBase<ApplicationUser>
    {
        //Task<PagedList<ApplicationUser>> FetchAllUserAsync(UserRequestParameters userRequestParameters);
       Task<ApplicationUser?> GetUserByEmailAsync(string email, bool asNoTracking = false);
     
        Task<bool> EmailExistsAsync(string email);
        Task<bool> UserNameExistsAsync(string userName);
        Task<bool> UserExistsAsync(string userId);
        Task<PagedList<ApplicationUser>> FetchAllUserAsync(UserRequestParameters userRequestParameters);
        Task<ApplicationUser?> GetUserWithOrdersAsync(string userId, bool asNoTracking = false);
    }
}
