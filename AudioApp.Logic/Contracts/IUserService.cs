using AudioApp.Logic.Models;
using AudioApp.Model;

namespace AudioApp.Logic.Contracts;

public interface IUserService
{
    public IEnumerable<UserBl> GetList();
    public UserBl Get(int id);
    public UserBl Create(UserBl bl);
    public UserBl Update(int id, UserBl bl);
    public void Delete(int id);
}