using AudioApp.DAL;
using AudioApp.Logic.Contracts;
using AudioApp.Logic.Extensions;
using AudioApp.Logic.Models;

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
        //  UserBl map to User

        throw new NotImplementedException();
    }

    public UserBl Update(int id, UserBl bl)
    {
        throw new NotImplementedException();
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
