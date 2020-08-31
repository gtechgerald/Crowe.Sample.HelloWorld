using System;
using System.Threading.Tasks; 
using Sample.HelloWorld.Business.Interfaces;


namespace Sample.HelloWorld.Business.Services
{
    public class DatabaseDataStoreService : IDataStoreService 
    {        
        public async Task<bool> Persist(object data)
        {
            //TODO: Implement code 
            return true;
        }
    }
}
