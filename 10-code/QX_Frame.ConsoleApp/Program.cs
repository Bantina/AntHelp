using Autofac;
using QX_Frame.App.Base;
using QX_Frame.Data.Contract;
using QX_Frame.Data.Entities;
using QX_Frame.Data.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.ConsoleApp
{
    class Program:AppBase
    {
        
        static void Main(string[] args)
        {
            var exam = Data.Entities.example.Build();
            exam.uid = Guid.NewGuid();
            exam.intValue = 333;
            exam.stringValue = "i like ioc";

            AppBase.RegisterEntity<Data.Entities.example>(exam);
            AppBase.GetBuilder().Register(c => new ExampleService(c.Resolve<IExampleService>(), c.Resolve<Data.Entities.example>()));

            var examService = AppBase.Fact<ExampleService>();

            example exa = examService.QuerySingle(default(Guid));

            Console.WriteLine($"the example is uid={exa.uid} , intValue={exa.intValue} , stringValue={exa.stringValue}");


            Console.WriteLine("any key to exit ...");
            Console.ReadKey();
        }
    }
}
