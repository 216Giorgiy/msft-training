using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageConsole {
    class Training : TableEntity {

        public Training() {
        }

        public string TrainingTest { get; set; }

    }
}
