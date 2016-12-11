using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QX_Frame.Helper_DG_Framework;
using QX_Frame.Model;
using QX_Frame.DAL.Service;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using QX_Frame.Base.Entities;
using QX_Frame.Base.Options;
using QX_Frame.Base.DB;

namespace QX_Frame.Test.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {



            int a = ProcessFlow_Helper_DG.channel_Exception_Log(() => Convert.ToInt32("3"));
            CWL(a);


            CWL("\nAny key to exit ...");

            Console.ReadKey();
        }



        //the quick console.writeline()
        static void CWL(dynamic str) => Console.WriteLine(str);
    }
}
