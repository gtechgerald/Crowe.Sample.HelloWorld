using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; 

namespace Sample.HelloWorld.Business.Interfaces
{
    public interface IHelloWorldService
    {
        /// <summary>
        /// Takes in a message
        /// </summary>
        /// <param name="message">Message to write to the service</param>
        /// <returns>Returns a hello world message</returns>
        Task<string> WriteMessage(string message); 
    }
}
