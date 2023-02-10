using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Katmanlar arasındaki bağlar interfaceler üzerinden kurulmuştur. Yani biz her yerde aslında interface talep ederiz bu sebepten yazılımımıza istediğimiz interfaceler karşılığında hangi classı vermesi gerektiğini söylememiz gerekir. 
            //Buna bağımlılık çözme denmektedir.
            //Autofac kütüphanesini kullanarak bağımlılıkları aşağıdaki örneklerdeki gibi çözebiliriz.
            //AspNetCore içerisinde default olarak bağımlılık çözücü servisi bulunur. İstenirse bu işlem direkt olarak API içerisinde Program.cs içerisinde de yapılabilir. 
            //Fakat genelde bağımlıklıkları Backend kısmında yönetmeyi tercih ederiz.
            //Autofack kütüphanesinin çalışabilmsi için API içerisndeki Program.cs içerisine gerekli comfigurasyon ypılmalıdır. Aksi takdirde servisimiz çalışmayacaktır.

            builder.RegisterType<ProjectNameContext>().As<DbContext>().SingleInstance();


            builder.RegisterType<ExampleRepository>().As<IExampleRepository>();
            builder.RegisterType<ExampleManager>().As<IExampleService>();
            
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();











            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
