
using Autofac;
using AzureFunctions.Autofac.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldFunction
{
    public class AutofacConfig
    {
        public AutofacConfig(string functionName) 
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterType<HwMessage>().As<IMessage>();


            }, functionName);
        }

        //public static IContainer Configure()
        //{
        //    var builder = new ContainerBuilder();

        //    builder.RegisterType<Message>().As<IMessage>();

        //    builder.RegisterAssemblyTypes(Assembly.Load(nameof(Message)))
        //        .Where(x => x.Namespace.Contains("Utilities"))
        //        .As(x => x.GetInterfaces().FirstOrDefault(y => y.Name == "I" + y.Name));

        //    return builder.Build();
        //}

        //public AutofacConfig() 
        //{
        //    DependencyInjection.Initialize(builder =>
        //    {
        //        builder.RegisterType<HelloWorldMessage>().As<IMessage>();
        //    });
        //}
    }
}
