using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Settings
{
    public class AzureStorageSettings
    {
        public string ConnectionString { get; set; }
        public string UserImagesContainerName { get; set; }
    
    }
}
