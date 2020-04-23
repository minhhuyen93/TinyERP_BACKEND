using TinyERP.Common.Enums;

namespace TinyERP.Common.DI
{
    public class ContainerFactory
    {
        public static IBaseContainer Create(ContainerType type)
        {
            switch (type)
            {
                case ContainerType.Windsor:
                default:
                    return new WindsorContainer();
            }
        }
    }
}
