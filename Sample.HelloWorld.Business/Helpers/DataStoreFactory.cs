using System;
using Sample.HelloWorld.Business.Interfaces;
using Sample.HelloWorld.Business.Services;
using System.Threading.Tasks; 

using Microsoft.Extensions.Logging; 

namespace Sample.HelloWorld.Business.Helpers
{
    public class DataStoreFactory : IDataStoreFactory
    {
        private readonly ILogger<DataStoreFactory> _logger; 

        public DataStoreFactory(ILogger<DataStoreFactory> logger)
        {
            _logger = logger; 
        }
        
        public async Task<IDataStoreService> CreateFileDataStoreService(string key)
        {
            try
            {
                //FUTURE ENHANCEMENT:  Create way to look up the data stores (configuration file, database etc.) 
                return new FileDataStoreService(); 
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"The following error occurred attempting to create an instance of the data store service for {key}"); 
                return null; 
            }
        }

        public async Task<IDataStoreService> CreateDatabaseDataStoreService(string key)
        {
            try
            {
                //FUTURE ENHANCEMENT:  Create way to look up the data stores (configuration file, database etc.) 
                return new DatabaseDataStoreService();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"The following error occurred attempting to create an instance of the data store service for {key}");
                return null;
            }
        }
    }
}
