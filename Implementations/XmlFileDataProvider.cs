using DataProviderFactory.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProviderFactory.Implementations
{
    public class XmlFileDataProvider : FileOperationsBase, IPersonDataProvider
    {
        public IList<IPersonData> ReadPersonData()
        {
            throw new NotImplementedException();
        }

        public void WritePersonData(IList<IPersonData> personData)
        {
            using (StreamWriter writer = new StreamWriter($@"{GetFilePath()}"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PersonData));

                foreach (var item in personData)                
                    serializer.Serialize(writer, item);                
            }
        }
    }
}
