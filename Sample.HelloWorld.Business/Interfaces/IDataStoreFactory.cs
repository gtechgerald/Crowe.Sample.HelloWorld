using System.Threading.Tasks; 

namespace Sample.HelloWorld.Business.Interfaces
{
    public interface IDataStoreFactory
    {
        /// <summary>
        /// Creates a data store service
        /// based on the key 
        /// </summary>
        /// <param name="key">Unique key to identify the data store</param>
        /// <returns>Instance of hte IDataStoreService if successful otherwise null</returns>
        Task<IDataStoreService> CreateDatabaseDataStoreService(string key);

        /// <summary>
        /// Creates a data store service
        /// based on the key 
        /// </summary>
        /// <param name="key">Unique key to identify the data store</param>
        /// <returns>Instance of hte IDataStoreService if successful otherwise null</returns>
        Task<IDataStoreService> CreateFileDataStoreService(string key); 
    }
}
