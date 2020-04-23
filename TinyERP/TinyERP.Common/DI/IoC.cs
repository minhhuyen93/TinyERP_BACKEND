using TinyERP.Common.Enums;

namespace TinyERP.Common.DI
{
    public class IoC
    {
        private static IBaseContainer Container;
        static IoC()
        {
            ContainerType type = ContainerType.Windsor;
            IoC.Container = ContainerFactory.Create(type);
        }
        public static IInterface Resolve<IInterface>() where IInterface : class
        {
            return IoC.Container.Resolve<IInterface>();
        }
        public static void RegisterTransient<IInterface, IImpl>()
            where IInterface : class where IImpl : IInterface
        {
            IoC.Container.RegisterTransient<IInterface, IImpl>();
        }
    }
}
