using System.Collections.Generic;

namespace DataProviderFactory.Contracts
{
    ///<summary> Contract for person data provider </summary>
    public interface IPersonDataProvider
    {
        IList<IPersonData> ReadPersonData();

        void WritePersonData(IList<IPersonData> personData);
    }
}