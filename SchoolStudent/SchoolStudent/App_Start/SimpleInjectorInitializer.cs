using System.Collections.Generic;
using System.Data.Entity;
using SchoolStudents.Domain;
using SchoolStudentsApi.Models;
using SchoolStudentsApi.UnitOfWork;

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
            container.Register<SchoolContext>(Lifestyle.Singleton);
            container.Register<DbContext,SchoolContext>(Lifestyle.Singleton);
            container.Register<IStudentRepository, StudentRepository>(Lifestyle.Singleton);
            container.Register<Student>(Lifestyle.Singleton);
            container.Register<Course>(Lifestyle.Singleton);
            container.Register<Department>(Lifestyle.Singleton);
            container.Register(typeof(GenericRepository<>));
            container.Register<UnitOfWork>(Lifestyle.Singleton);
        }
    }
}