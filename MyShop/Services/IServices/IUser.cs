using MyShop.Models.Dtos;
using MyShop.Models;

namespace MyShop.Services.IServices
{
    public interface IUser
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(Guid id);
        Task<string> AddUserAsync(User user);
        Task<string> UpdateUserAsync( User user);
        Task<string> DeleteProductAsync(User user);
    }
}
