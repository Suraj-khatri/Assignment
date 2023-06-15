using Assignment.Models;
using Assignment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class App
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IAdminService adminService;
        public App(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        
        public void Main()
        {
           
            var isAppRunning = true;
            Console.WriteLine("WelCome To Contact Management Software");
            while (isAppRunning)
            {
                Option();
                var input = Console.ReadLine();
                switch(input)
                {
                    case "5":
                        Console.WriteLine("Enter Email Or PhoneNumber:");
                        var searchParam = Console.ReadLine();
                        var searchReasult = _userInfoService.Search(searchParam);
                        ListAllContact(searchReasult);
                        break;
                    case "4":
                        var userinfos = _userInfoService.GetAllUserInfo();

                        ListAllContact(userinfos);
                        Console.WriteLine("Id");
                        var updateId = Console.ReadLine();
                        while (string.IsNullOrEmpty(updateId))
                        {
                            Console.WriteLine("Id cannot be null");
                            Console.Write("Id:");
                            updateId = Console.ReadLine();
                        }
                        var updateIsSuccess = Guid.TryParse(updateId, out Guid updateGuid);
                        if (updateIsSuccess)
                        {
                            var getByIdResponse = _userInfoService.GetUserInfoById(updateGuid);
                            if(getByIdResponse == null)
                            {
                                Console.WriteLine("UserNotFound");
                            }
                            else
                            {
                                Console.WriteLine("Phone:");
                                var phone = Console.ReadLine();
                                while(string.IsNullOrEmpty(phone))
                                {
                                    Console.WriteLine("PhoneNumber Cannot Be Null");
                                    Console.WriteLine("PhoneNumber");
                                    phone = Console.ReadLine();
                                }
                                var res = adminService.UpdatePhone(updateGuid, phone);
                                Console.WriteLine(res);
                            }

                        }
                        else
                        {
                            Console.WriteLine("You Have Entered Invalid Id");
                        }
                        break;
                    case "3":
                        var userinfos3 = _userInfoService.GetAllUserInfo();

                        ListAllContact(userinfos3);
                        Console.WriteLine("choose the id you want to delete");
                        var id =Console.ReadLine();
                        while (string.IsNullOrEmpty(id))
                        {
                            Console.WriteLine("Id cannot be null");
                            Console.Write("Id:");
                            id = Console.ReadLine();
                        }
                        var isSuccess = Guid.TryParse(id, out Guid result);
                        if(isSuccess)
                        {
                            var res = adminService.DeleteUserInfo(result);
                            Console.WriteLine(res);
                        }
                        else
                        {
                            Console.WriteLine("You Have Entered Invalid Id");
                        }
                        break;
                    case "2":
                        var userinfos2 = _userInfoService.GetAllUserInfo();
                        ListAllContact(userinfos2);
                        break;
                    case "1":
                        var userinfo = new UserInfoModel();
                        userinfo.Id = Guid.NewGuid();
                        Console.Write("FirstName:");
                        userinfo.FirstName = Console.ReadLine();
                        while(string.IsNullOrEmpty(userinfo.FirstName))
                        {
                            Console.WriteLine("FirstName cannot be null");
                            Console.Write("FirstName:");
                            userinfo.FirstName = Console.ReadLine();
                        }
                        Console.Write("MiddleName:");
                        userinfo.MiddleName = Console.ReadLine();
                        Console.Write("LastName:");
                        userinfo.LastName = Console.ReadLine();
                        while (string.IsNullOrEmpty(userinfo.LastName))
                        {
                            Console.WriteLine("LastName cannot be null");
                            Console.Write("LastName:");
                            userinfo.LastName = Console.ReadLine();
                        }
                        Console.Write("Email:");
                        userinfo.Email = Console.ReadLine();
                        while (string.IsNullOrEmpty(userinfo.Email))
                        {
                            Console.WriteLine("Email cannot be null");
                            Console.Write("Email:");
                            userinfo.Email = Console.ReadLine();
                        }
                        Console.Write("Phone:");
                        userinfo.PhoneNumber = Console.ReadLine();
                        while (string.IsNullOrEmpty(userinfo.PhoneNumber))
                        {
                            Console.WriteLine("Phone cannot be null");
                            Console.Write("Phone:");
                            userinfo.PhoneNumber = Console.ReadLine();
                        }
                        var response = adminService.AddUserInfo(userinfo);
                        Console.WriteLine(response);

                        break;
                    case "0":
                        isAppRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
        public void ListAllContact(List<UserInfoModel> userinfos)
        {
            if(!userinfos.Any())
            {
                Console.WriteLine("No Any Contact Found!!!");
            }
            foreach (var item in userinfos)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"FirstName: {item.FirstName}");
                Console.WriteLine($"MiddleName: {item.MiddleName}");
                Console.WriteLine($"LastName: {item.LastName}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine($"Phone: {item.PhoneNumber}");
                Console.WriteLine("---------------------------------------------------");
            }
        }

        public static void Option()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Please Choose Your Option");
            Console.WriteLine("1.Add Contact");
            Console.WriteLine("2.Get All Contact");
            Console.WriteLine("3.Delete Contact");
            Console.WriteLine("4.Update Contact");
            Console.WriteLine("5.Search");
            Console.WriteLine("0.Exit");
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
