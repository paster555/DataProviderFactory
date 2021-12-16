using DataProviderFactory.Implementations;

namespace DataProviderFactory.Contracts
{
    /// <summary> Person data contract </summary>
    public interface IPersonData
    {
        /// <summary> Person  name </summary>
        string Name { get; set; }
        /// <summary> Person  address </summary>
        PersonAddress Address { get; set; }

    }
}