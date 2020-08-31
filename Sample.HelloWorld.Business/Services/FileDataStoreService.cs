using System;
using Sample.HelloWorld.Business.Interfaces;
using System.Threading.Tasks; 

namespace Sample.HelloWorld.Business.Services
{
    public class FileDataStoreService : IDataStoreService
    {        
        public async Task<bool> Persist(object data)
        {
            //TODO: Implement code 
            return true; 
        }
    }
}
