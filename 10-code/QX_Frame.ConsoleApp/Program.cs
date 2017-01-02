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
            AppBase.RegisterEntity<example>(exam);
            AppBase.RegisterType<ExampleService, IExampleService>();

            AppBase.builder.Register(c => new ExampleService(c.Resolve<IExampleService>(), c.Resolve<example>()));

            var examService = Fact<IExampleService>();

            example exa = examService.QuerySingle(Guid.NewGuid());

            Console.WriteLine($"the example is uid={exa.uid} , intValue={exa.intValue} , stringValue={exa.stringValue}");


            Console.WriteLine("any key to exit ...");
            Console.ReadKey();
        }
    }
}
