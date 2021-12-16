using DataProviderFactory.Contracts;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataProviderFactory.Implementations
{
    
    public class CsvFileDataProvider: FileOperationsBase, IPersonDataProvider
    {
        public IList<IPersonData> ReadPersonData()
        {
            return File.ReadAllLines($@"{GetFilePath()}").Skip(1)
                 .Select(csvLine => MapValuesFromCsvLine(csvLine))
                 .ToList();
        }

        public void WritePersonData(IList<IPersonData> personData)
        {
            throw new System.NotImplementedException();
        }

       

       
        private string[] ParseCsvLine(string csvLine)
        {            
            TextFieldParser parser = new TextFieldParser(new StringReader(csvLine));
            parser.HasFieldsEnclosedInQuotes = csvLine.Contains(",\"") || csvLine.Contains("\",");
            parser.SetDelimiters(",");
            string[] parsedLine = parser.ReadFields();
            parser.Close();
            return parsedLine;
        }

       

        private IPersonData MapValuesFromCsvLine(string csvLine)
        {
            string[] lineValues = ParseCsvLine(csvLine);
            return new PersonData
            {
                Name = lineValues[0],
                Address=new PersonAddress
                {
                    line1 = lineValues[1],
                    line2 = lineValues[2]
                }               
            };
        }

    }
}