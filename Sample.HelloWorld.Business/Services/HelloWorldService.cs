using System;
using Sample.HelloWorld.Business.Interfaces;
using Sample.HelloWorld.Business.Settings; 
using Microsoft.Extensions.Logging;
using System.Threading.Tasks; 

namespace Sample.HelloWorld.Business.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        private readonly ILogger<HelloWorldService> _logger;
        private readonly DataStoreSettings _dataStoreSettings;
        private readonly IDataStoreFactory _dataStoreFactory; 

        public HelloWorldService(ILogger<HelloWorldService> logger, DataStoreSettings dataStoreSettings, IDataStoreFactory dataStoreFactory)
        {
            _logger = logger;
            _dataStoreSettings = dataStoreSettings;
            _dataStoreFactory = dataStoreFactory; 
        }

        public async Task<string> WriteMessage(string message)
        {
            //FUTURE ENHANCEMENT: Use the DataStoreSettings to write to one or multiple data stores              
            var fileDataStoreKeys = _dataStoreSettings.FileDataStoreKeys.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var databaseDataStoreKeys = _dataStoreSettings.DatabaseDataStoreKeys.Split(',', StringSplitOptions.RemoveEmptyEntries); 

            foreach(var fileDataStoreKey in fileDataStoreKeys)
            {                                
                var fileDataStoreService = await _dataStoreFactory.CreateFileDataStoreService(fileDataStoreKey);

                if(fileDataStoreService != null)
                {
                    var filePersistResult = await fileDataStoreService.Persist(message);
                }                                
            }

            foreach(var databaseDataStoreKey in databaseDataStoreKeys)
            {
                var databaseDataStoreService = await  _dataStoreFactory.CreateDatabaseDataStoreService(databaseDataStoreKey); 

                if(databaseDataStoreService != null)
                {
                    var dbPersistResult = await databaseDataStoreService.Persist(message); 
                }
            }

            return $"Hello World"; 
        }
    }
}
