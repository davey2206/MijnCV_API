using MijnCV_API.Models;

namespace MijnCV_API.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetUsers();
        public Task<User?> GetUser(int id);
        public Task<bool> PutUser(int id, User user);
        public Task PostUser(User user);
        public Task<bool> DeleteUser(int id);
        public bool UserExists(int id);
    }
}
