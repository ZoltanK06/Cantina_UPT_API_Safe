using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using CantinaUPT_API.Core.Interfaces;
using CantinaUPT_API.Core.ProjectAggregate;
using CantinaUPT_API.Core.ProjectAggregate.Specifications;
using CantinaUPT_API.SharedKernel.AppConstants;
using CantinaUPT_API.SharedKernel.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace CantinaUPT_API.Core.Services;
public class AuthService : IAuthService
{

  private readonly IReadRepository<User> _readRepository;
  private readonly IRepository<User> _repository;

  public AuthService(IReadRepository<User> readRepository, IRepository<User> repository)
  {
    _readRepository = readRepository;
    _repository = repository;
  }

  public EncryptedPassword CreatePasswordHash(string password)
  {
    byte[] passwordSalt;
    byte[] passwordHash;

    using (var hmac =  new HMACSHA512())
    {
      passwordSalt = hmac.Key;
      passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    return new EncryptedPassword
    {
      PasswordHash = passwordHash,
      PasswordSalt = passwordSalt
    };
  }

  public bool VerifyPasswordHash(string password, byte[] existingPasswordHash, byte[] existingPasswordSalt)
  {
    using (var hmac = new HMACSHA512(existingPasswordSalt))
    {
      var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      return computedHash.SequenceEqual(existingPasswordHash);
    }
  }

  public string CreateToken(User user)
  {
    List<Claim> claims = new List<Claim>
    {
      new Claim(ClaimTypes.Sid, user.Id.ToString()),
      new Claim(ClaimTypes.Role, user.Role.RoleName)
    };

    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("1234!@#$4321$#@!"));
    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    var token = new JwtSecurityToken(
      claims: claims,
      expires: DateTime.Now.AddHours(12),
      signingCredentials: credentials
     ) ;

    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

    return jwt;
  }

  public async Task<LoginResponse> Login(LoginRequest user)
  {

    var specification = new CheckIfUserAlreadyExists(new User { Username = user.Username, Email = user.Email });
    var existingUser = await _readRepository.FirstOrDefaultAsync(specification);

    if (existingUser == null)
    {
      return new LoginResponse { Error = AppConstants.UserNotFound };
    }
    if(!VerifyPasswordHash(user.Password, existingUser.PasswordHash, existingUser.PasswordSalt))
    {
      return new LoginResponse { Error = AppConstants.WrongPassword };
    }

      string token = CreateToken(existingUser);
      return new LoginResponse { Token = token, Role = existingUser.Role.RoleName, UserId = existingUser.Id, CanteenId = existingUser.Canteen?.Id };
  }

  public async Task<bool> Register(User user)
  {
    var specification = new CheckIfUserAlreadyExists(user);
    var existingUser = await _readRepository.AnyAsync(specification);
    if (existingUser)
    {
      return false;
    }
    else
    {
      await _repository.AddAsync(user);
      await _repository.SaveChangesAsync();
      return true;
    }
  }

  public async Task<List<User>> GetAllManagers()
  {
    var specification = new FilterManagers();
    return await _readRepository.ListAsync(specification);
  }

  public async Task DeleteUser(int userId)
  {
    var user = await _readRepository.GetByIdAsync(userId);
    await _repository.DeleteAsync(user);
    await _repository.SaveChangesAsync();
  }

  public async Task UpdateUser(User user)
  {
    var specification = new CheckIfUserAlreadyExists(user);
    var oldUser = await _readRepository.GetBySpecAsync(specification);
    if (user.PasswordHash == null || user.PasswordSalt == null)
    {
      oldUser.Username = user.Username;
      oldUser.Role = user.Role;
      oldUser.Canteen = user.Canteen;
      oldUser.Email = user.Email;
    }
    else
    {
      oldUser.Username = user.Username;
      oldUser.Role = user.Role;
      oldUser.Canteen = user.Canteen;
      oldUser.Email = user.Email;
      oldUser.PasswordHash = user.PasswordHash;
      oldUser.PasswordSalt = user.PasswordSalt;
    }
    
    await _repository.UpdateAsync(oldUser);
    await _repository.SaveChangesAsync();
  }
}
