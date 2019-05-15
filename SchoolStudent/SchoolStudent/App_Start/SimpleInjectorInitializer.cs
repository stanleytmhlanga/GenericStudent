using System.Collections.Generic;
using System.Data.Entity;
using SchoolStudents.Domain;
using SchoolStudentsApi.Models;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SchoolStudent.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace SchoolStudent.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using SchoolStudentsApi.Repositories;
    using SchoolStudentsApi.Interfaces;
    using System.Configuration;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //var ConnectionString = ConfigurationManager.ConnectionStrings["StudentDb"];

            //container.Register<DbContext>(() =>
            //{

            //    //var conString = Configuration.GetConnectionString("DefaultConnection");
            //    //var options = "DefaultConnection";
            //    return new SchoolContext(ConnectionString.ConnectionString);

            //});


            container.Register<SchoolContext>(Lifestyle.Singleton);
            container.Register<DbContext,SchoolContext>(Lifestyle.Singleton);
            container.Register<IStudentRepository, StudentRepository>(Lifestyle.Singleton);
           
            container.Register<Student>(Lifestyle.Singleton);
            //container.Register<IStudentRepository>();
            //container.Register<StudentRepository>(Lifestyle.Scoped);

            // Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}