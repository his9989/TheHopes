using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PEMServer.Models;


namespace PEMServer.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsers();  //모든 유저 반환
        User GetUsers(string ObjName); //이니셜로 유저 찾기
        string UpdateEdit(string ObjName, int Edit);    //이니셜로 유저 edit column update
    }
}
