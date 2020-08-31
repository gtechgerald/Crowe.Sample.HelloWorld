using System;
using System.Collections.Generic;
using System.Text;
using Sample.HelloWorld.Business.Interfaces; 

namespace Sample.HelloWorld.Business.Settings
{
    public class DataStoreSettings
    {
        /// <summary>
        /// This will be a comma delimited list of the 
        /// various file data store keys
        /// </summary>
        public string FileDataStoreKeys { get; set; }

        /// <summary>
        /// This will be a comma delimited list of the 
        /// various file data store keys
        /// </summary>
        public string DatabaseDataStoreKeys { get; set; }
    }
}
