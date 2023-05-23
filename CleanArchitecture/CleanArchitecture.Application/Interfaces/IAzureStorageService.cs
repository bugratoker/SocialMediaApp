using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IAzureStorageService
    {
        public Task<string> UploadUserImageToBlob(byte[] image, string contentType);
    }
}
