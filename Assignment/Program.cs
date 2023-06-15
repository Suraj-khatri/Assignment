using Assignment.Services;
using Assignment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<App>();

            //yesley k vancha vane, throughout the code,IUserInfoService call huda yesley chai UserInfoService lai refrence garcha
            serviceCollection.AddSingleton<IUserInfoService, UserInfoService>(); 

            // it will build all the above service and provide service and we can get any services from here
            var serviceprovider = serviceCollection.BuildServiceProvider();


            // we are getting all the service from this <App> and give to this app
            var app = serviceprovider.GetService<App>();

            //now we call the Main function of app
            app.Main();
            //we can call other function also....if there was another function main2 then
            //app.Main2();
        }
    }
}
