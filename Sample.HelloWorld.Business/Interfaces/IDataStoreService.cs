using System.Threading.Tasks; 

namespace Sample.HelloWorld.Business.Interfaces
{
    /// <summary>
    /// Interface for persisting data to a store (Database, File, etc.) 
    /// </summary>
    public interface IDataStoreService
    {
        /// <summary>
        /// Persist an object to the data store 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> Persist(object data); 
    }
}
