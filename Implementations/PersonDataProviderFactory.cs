using DataProviderFactory.Contracts;
using DataProviderFactory.Enums;
using Unity;

namespace DataProviderFactory.Implementations
{
    public class PersonDataProviderFactory : IPersonDataProviderFactory
    {
        private readonly IUnityContainer m_UnityContainer;
        public PersonDataProviderFactory(IUnityContainer unityConteiner)
        {
            m_UnityContainer = unityConteiner;
        }

        public IPersonDataProvider GetPersonDataProvider(ActionType actionType)
        {
            return m_UnityContainer?.Resolve<IPersonDataProvider>(actionType.ToString());
        }
    }
}
