using System;
using BLL;
using Unity;
using BALUser;
using Shared_Library.Interface;
using DAL.UnitOfWork;
using Unity.Injection;
using DAL.Repositories;
using DAL.InterfaceRepo;

namespace BookEventManager
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            //container.RegisterType<IUnitofWork, UoWBook>("book");
            //container.RegisterType<IUnitofWork, UoWUser>("user");

            //for repos to Unit of Work
            container.RegisterType<IUnitofWork, UoWBook>();
            container.RegisterType<BookRepository>(new InjectionConstructor(container.Resolve<IUnitofWork>()));

            container.RegisterType<IUnitofWork, UoWUser>();
            container.RegisterType<UserRepository>(new InjectionConstructor(container.Resolve<IUnitofWork>()));


            //for BAL to Repos
            container.RegisterType<IBookRepo, BookRepository>();
            container.RegisterType<BusinessLogicBook>(new InjectionConstructor(container.Resolve<IBookRepo>()));

            container.RegisterType<IUserRepo, UserRepository>();
            container.RegisterType<BusinessLogicUser>(new InjectionConstructor(container.Resolve<IUserRepo>()));


            //for BAL
            container.RegisterType<IBusinessBook,BusinessLogicBook>();
            container.RegisterType<IBusinessUser, BusinessLogicUser>();

        }
    }
}