using DataProviderFactory.Contracts;

namespace DataProviderFactory.Implementations
{
    public class PersonAddress : IPersonAddress
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
    }
}