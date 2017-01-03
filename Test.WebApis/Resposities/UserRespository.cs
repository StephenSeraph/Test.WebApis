using System;
using System.Collections.Generic;
using System.Linq;
using Test.WebApis.Models;

public interface IUserRespository
{
    IEnumerable<UserInfo> GetUser();

    bool CreateUser(UserInfo value);

    bool UpdateUser(UserInfo value);

    bool DeleteUser(UserInfo value);
}

public class UserRespository : IUserRespository
{
    private User _user;

    public UserRespository()
    {
        _user = new User();
    }

    public bool CreateUser(UserInfo value)
    {
        if (value != null)
        {
            _user.Users.Add(value);
            _user.SaveChanges();
            return true;
        }
        return false;
    }

    public bool DeleteUser(UserInfo value)
    {
        var user = _user.Users.FirstOrDefault(p => p.Id == value.Id);
        if (user != null)
        {
            _user.Users.Remove(user);
            _user.SaveChanges();
        }
        return true;
    }

    public IEnumerable<UserInfo> GetUser()
    {
        return _user.Users;
    }

    public bool UpdateUser(UserInfo value)
    {
        var user = _user.Users.FirstOrDefault(p => p.Id == value.Id);
        if (user != null)
        {
            user.IDCard = value.IDCard;
            user.Name = value.Name;
            user.Phone = value.Phone;
            _user.SaveChanges();
        }
        return true;
    }
}