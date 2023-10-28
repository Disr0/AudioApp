using AudioApp.DAL;
using AudioApp.Logic.Contracts;
using AudioApp.Logic.Extensions;
using AudioApp.Logic.Models;
using System.Reflection.Metadata;

namespace AudioApp.Logic.Impl;

public class UserService : IUserService
{
    readonly AudioAppContext _dbContext;
    public UserService(AudioAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<UserBl> GetList()
        => _dbContext.Users.Select(_ => _.toBl());

    public UserBl Get(int id)
    {
        var res = _dbContext.Users.Find(id);
        if (res is null)
            return default;

        return res.toBl();
    }


    public UserBl Create(UserBl bl)
    {
        if (bl.Age != 0 && bl.Name != null && bl.LastName != null && _dbContext.Users.Any(c => c.Id != bl.Id))
        {
            var newUser = new Model.User
            {
                Age = bl.Age,
                Name = bl.Name,
                LastName = bl.LastName,
                Id = bl.Id
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return bl;
        }
        throw new FormatException(); 
    }

    public UserBl Update(int id, UserBl bl)
    {
        if (bl.Age != 0 && bl.Name != null && bl.LastName != null && _dbContext.Users.Any(c => c.Id != bl.Id))
        {
            var newUser = new Model.User
            {
                Age = bl.Age,
                Name = bl.Name,
                LastName = bl.LastName,
                Id = bl.Id
            };
            var result = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            if (result != null)
            {
                result = newUser;
                _dbContext.SaveChanges();
                return bl;
            }
        }
        throw new FormatException();
    }

    public void Delete(int id)
    {
        var user = _dbContext.Users.Find(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }

}
