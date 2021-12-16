using DataProviderFactory.Contracts;
using DataProviderFactory.Enums;
using DataProviderFactory.Implementations;
using System;
using System.Collections.Generic;
using Unity;

namespace DataProviderFactory
{
    class Program
    {
        static IUnityContainer container = new UnityContainer();
        static void Main(string[] args)
        {
            RequestedActions requestedAction = CaptureUserRequest();
            var processorFactory = container.Resolve<IPersonDataProviderFactory>();

            var personDataProvider = processorFactory?.GetPersonDataProvider(requestedAction.ActionsToPerform[0]);
            var retrievedData = personDataProvider?.ReadPersonData();
            
            if (retrievedData.Equals(null))
                return;

            personDataProvider = processorFactory?.GetPersonDataProvider(requestedAction.ActionsToPerform[1]);
           if(retrievedData!=null && retrievedData.Count>0)         
                personDataProvider.WritePersonData(retrievedData);            
        }

        private static RequestedActions CaptureUserRequest()
        {
            var requestedAction = new RequestedActions();
            RegisterDependencies();
            Console.WriteLine("Read from: 1 - CSV, 2 - ..., 3 - ...");
            requestedAction.ActionsToPerform.Add(GetUserInputToReadFrom());
            Console.WriteLine("Write to: 1 - ..., 2 - XML, 3 - JSON");
            requestedAction.ActionsToPerform.Add(GetUserInputToWriteTo());
            return requestedAction;
        }

        private static ActionType GetUserInputToReadFrom()
        {
            var userchoice = Console.ReadLine();
            switch (userchoice)
            {
                case "1":
                    return ActionType.ReadCsv;
                case "2":
                    return ActionType.ReadXml;
                case "3":
                    return ActionType.ReadJson;

                default:return ActionType.None;                    
            }
        }

        private static ActionType GetUserInputToWriteTo()
        {
            var userchoice = Console.ReadLine();
            switch (userchoice)
            {
                case "1":
                    return ActionType.WriteCsv;
                case "2":
                    return ActionType.WriteXml;
                case "3":            
                    return ActionType.WriteJason;

                default: return ActionType.None;
            }
        }

        private static void RegisterDependencies()
        {
            
            container.RegisterType<IPersonDataProvider, CsvFileDataProvider>(ActionType.ReadCsv.ToString());
            container.RegisterType<IPersonDataProvider, XmlFileDataProvider>(ActionType.WriteXml.ToString());
            container.RegisterType<IPersonDataProvider, JsonFileDataProvider>(ActionType.WriteJason.ToString());
            container.RegisterType<IPersonDataProviderFactory, PersonDataProviderFactory>();
        }

        private class RequestedActions
        {
            public IList<ActionType> ActionsToPerform = new List<ActionType>();
        }
        
    }
}
