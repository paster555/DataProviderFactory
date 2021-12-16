using DataProviderFactory.Contracts;

namespace DataProviderFactory.Implementations
{
    public class PersonData : IPersonData
    {
        public string Name { get ; set ; }
        public PersonAddress Address { get; set; }
    }
}