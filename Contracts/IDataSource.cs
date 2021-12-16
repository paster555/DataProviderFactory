namespace DataProviderFactory.Contracts
{
    /// <summary> Data source contract </summary>
    public interface IDataSource
    {
        /// <summary> Data source details </summary>
        string FileDetails { get; set; }
    }
}