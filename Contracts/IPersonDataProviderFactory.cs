using DataProviderFactory.Enums;

namespace DataProviderFactory.Contracts
{
    ///<summary> Contract for person data provider factory </summary>
    public interface IPersonDataProviderFactory
    {
        IPersonDataProvider GetPersonDataProvider(ActionType actionType);
    }
}