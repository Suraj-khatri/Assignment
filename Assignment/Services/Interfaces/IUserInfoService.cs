using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services.Interfaces
{
    public interface IUserInfoService
    {
       
        List<UserInfoModel> GetAllUserInfo();
        UserInfoModel GetUserInfoById(Guid id);
       
        List<UserInfoModel> Search(string query);
    }
    public interface IAdminService
    {
        string AddUserInfo(UserInfoModel userInfoModel);
        string UpdatePhone(Guid Id, string Phone);
        string DeleteUserInfo(Guid id);
    }
}
