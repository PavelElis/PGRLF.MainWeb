using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace PGRLF.AzureStorageProvider.TableEntities
{
    public class Form : TableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TechName { get; set; }

        [DisplayName("Valid from:")]
        [DataType(DataType.DateTime)]

        public DateTime ValidFrom { get; set; }

        [DisplayName("Valid to:")]
        [DataType(DataType.DateTime)]

        public DateTime ValidTo { get; set; }

        public string LinkToDescription { get; set; }

    }
}
