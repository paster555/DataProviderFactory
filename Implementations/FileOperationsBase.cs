using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProviderFactory.Implementations
{
    public abstract class FileOperationsBase
    {
        protected virtual string GetFilePath()
        {
            Console.WriteLine("Please enter valid file path:");
            return Console.ReadLine();
        }
    }
}
