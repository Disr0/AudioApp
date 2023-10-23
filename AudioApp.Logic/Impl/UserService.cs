using AudioApp.DAL;
using AudioApp.Logic.Contracts;
using AudioApp.Model;

namespace AudioApp.Logic.Impl;

public class UserService : IUserService
{
    readonly AudioAppContext _dbContext;
    public UserService(AudioAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<User> GetList()
     => _dbContext.Users.ToArray();

    public User Get(int id)
    {
        return _dbContext.Users.Find(id);
    }


    public User Create(User newUser)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        var user = _dbContext.Users.Find(id);
        if (user != null) 
        {
            _dbContext.Users.Remove(user);
            bool result = _dbContext.SaveChanges() > 0 ? true : false;
            return result;
        }
        return false;
    }

    public User Update(int id, User user)
    {
        throw new NotImplementedException();
    }
}
