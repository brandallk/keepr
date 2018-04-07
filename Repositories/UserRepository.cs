using System;
using System.Data;
using Dapper;
using keepr.Models;
using keepr.Models.AuxiliaryModels;
using MySql.Data.MySqlClient;

namespace keepr.Repositories
{
  public class UserRepository : DbContext
  {
    public UserRepository(IDbConnection db) : base(db)
    {
    }

    public UserReturnModel Register(UserRegisterModel creds)
    {
      Guid randomStringId = Guid.NewGuid();

      User user = new User()
      {
        Id = randomStringId.ToString(),
        Username = creds.Username,
        Email = creds.Email,
        Password = BCrypt.Net.BCrypt.HashPassword(creds.Password)
      };

      try
      {
        var rowsAffected = _db.Execute(@"
        INSERT INTO users (Id, Username, Email, Password)
        VALUES (@Id, @Username, @Email, @Password);
        SELECT LAST_INSERT_ID();
        ", user);

        if (rowsAffected > 0)
        {
          return new UserReturnModel()
          {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
          };
        }
      }
      catch (MySqlException e)
      {
        Console.WriteLine("ERROR: {0}", e.Message);
        return null;
      }
      return null;
    }

    public UserReturnModel Login(UserLoginModel creds)
    {
      User user = _db.QueryFirstOrDefault<User>(@"
      SELECT * FROM users WHERE email = @Email
      ", creds);

      if (user != null)
      {
        var valid = BCrypt.Net.BCrypt.Verify(creds.Password, user.Password);
        if (valid)
        {
          return user.GetReturnModel();
        }
      }
      return null;
    }

    public UserReturnModel GetUserByEmail(string email)
    {
      User user = _db.QueryFirstOrDefault<User>(@"
      SELECT * FROM users WHERE email = @Email
      ", new { email });
      return user.GetReturnModel();
    }

    public UserReturnModel GetUserById(string id)
    {
      User savedUser = _db.QueryFirstOrDefault<User>(@"
      SELECT * FROM users WHERE id = @id
      ", new { id });
      return savedUser.GetReturnModel();
    }

    public UserReturnModel UpdateUser(UserReturnModel user)
    {
      var rowsAffected = _db.Execute(@"
      UPDATE users SET
        email = @Email,
        username = @Username
      WHERE id = @id
      ", user);

      if (rowsAffected > 0)
      {
        return user;
      }
      return null;
    }

    public string ChangeUserPassword(UserChangePasswordModel user)
    {
      User savedUser = _db.QueryFirstOrDefault<User>(@"
      SELECT * FROM users WHERE id = @id
      ", user);

      var valid = BCrypt.Net.BCrypt.Verify(user.OldPassword, savedUser.Password);
      if (valid)
      {
        user.NewPassword = BCrypt.Net.BCrypt.HashPassword(user.NewPassword);
        var rowsAffected = _db.Execute(@"
        UPDATE users SET
          password = @NewPassword
        WHERE id = @id
        ", user);
        return "Password successfully changed";
      }
      return "Unable to change password";
    }
  }
}