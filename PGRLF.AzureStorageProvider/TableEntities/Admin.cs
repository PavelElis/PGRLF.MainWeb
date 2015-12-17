using Microsoft.WindowsAzure.Storage.Table;

namespace PGRLF.AzureStorageProvider.TableEntities
{
    class Admin :TableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
