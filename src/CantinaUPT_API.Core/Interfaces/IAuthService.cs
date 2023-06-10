using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CantinaUPT_API.Core.ProjectAggregate;

namespace CantinaUPT_API.Core.Interfaces;
public interface IAuthService
{
  EncryptedPassword CreatePasswordHash(string password);
  bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] existingPasswordSalt);
  Task<bool> Register(User user);
  Task<LoginResponse> Login(LoginRequest user);
  Task<List<User>> GetAllManagers();
  Task DeleteUser(int userId);
  Task UpdateUser(User user);
}
