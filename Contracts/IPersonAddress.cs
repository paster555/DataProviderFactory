namespace DataProviderFactory.Contracts
{
    /// <summary> Person address contract </summary>
    public interface IPersonAddress
    {
        /// <summary> address line one </summary>
        string line1 { get; set; }
        /// <summary> address line two </summary>
        string line2 { get; set; }
    }
}