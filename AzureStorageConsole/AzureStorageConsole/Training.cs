using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageConsole {
    class Training : TableEntity {

        public Training() {
            this.PartitionKey = "3"";"
        }

        public string TrainingTest { get; set; }

        public string Naam { get; set; }

    }
}
