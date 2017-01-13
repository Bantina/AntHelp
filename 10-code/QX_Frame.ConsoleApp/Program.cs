﻿using QX_Frame.App.Base;
using QX_Frame.Data.Entities.QX_Frame;
using QX_Frame.Data.QueryObject;
using QX_Frame.Data.Service.QX_Frame;
using System;
using System.Collections.Generic;

namespace QX_Frame.ConsoleApp
{
    class Program : AppBase
    {

        static void Main(string[] args)
        {
            UserAccountQueryObject query = new UserAccountQueryObject();
            

            AppBase.Register(c => new UserAccountService());

            using (var fact=Wcf<UserAccountService>())
            {
                var channel = fact.CreateChannel();
                int count;
                List<tb_userAccount> list = channel.QueryAll(query).Cast<List<tb_userAccount>>(out count);
                Console.WriteLine($"count={count}");
                foreach (var item in list)
                {
                    Console.WriteLine($"item loginId={item.loginId}");
                }
            }

            Console.WriteLine("any key to exit ...");
            Console.ReadKey();
        }
    }
}
