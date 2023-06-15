using Assignment.Models;
using Assignment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services
{
    public class UserInfoService : IUserInfoService , IAdminService
    {
        public List<UserInfoModel> UserInfos { get; set; }

        public UserInfoService() 
        {
            UserInfos = new List<UserInfoModel>();
        }

        public string AddUserInfo(UserInfoModel userInfoModel)
        {
            UserInfos.Add(userInfoModel);
            return "Added success";
        }

        public List<UserInfoModel> GetAllUserInfo()
        {
 
            return UserInfos;
        }

        public UserInfoModel GetUserInfoById(Guid id)
        {
            return UserInfos.FirstOrDefault(x => x.Id == id);
        }

        public string DeleteUserInfo(Guid id)
        {
            var item = GetUserInfoById(id);
            if (item == null)
            {
                Console.WriteLine("User Doesnot Exist!!!");
            }
            UserInfos.Remove(item);
            return "Deleted Successfully";
        }

        public string UpdatePhone(Guid Id, string Phone)
        {
            var item = UserInfos.Find(x => x.Id == Id);
            item.PhoneNumber = Phone;
            return "Updates successfully";
        }

        public List<UserInfoModel> Search(string query)
        {
            var result = UserInfos.Where(x => x.Email.ToLower().StartsWith(query.ToLower()) || x.PhoneNumber.StartsWith(query)).ToList();
            return result;
        }
    }
}
