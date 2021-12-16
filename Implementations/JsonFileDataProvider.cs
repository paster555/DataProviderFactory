using DataProviderFactory.Contracts;
using DataProviderFactory.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataProviderFactory.Implementations
{
    public class JsonFileDataProvider : FileOperationsBase, IPersonDataProvider
    {
        private readonly JsonSerializer m_Serialiser;
        private readonly Dictionary<ActionType, object> m_avaolableAction;
        public JsonFileDataProvider()
        {
            m_Serialiser = new JsonSerializer();
            m_Serialiser.NullValueHandling = NullValueHandling.Ignore;
            
        }

        public IList<IPersonData> ReadPersonData()
        {
            throw new NotImplementedException();
        }

        public void WritePersonData(IList<IPersonData> personData)
        {
            using (StreamWriter sw = new StreamWriter($@"{GetFilePath()}"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                foreach (var item in personData)
                {
                    m_Serialiser.Serialize(writer, item);
                }
                            
            }
        }
    }
}
