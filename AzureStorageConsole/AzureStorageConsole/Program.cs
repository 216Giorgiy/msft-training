using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageConsole {
    class Program {
        static void Main(string[] args) {
            UploadFile();
        }

        static void UploadFile() {

            CloudStorageAccount storageAccount = null;
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=functionaction89d3;AccountKey=A/n6F2247fCMwKLtjml69PH5tlm51bCfe3o/I0hpV371Tf6PjFkHguScMTo5+Y9kolfI9bQdcrEcKJoS2apmAQ==;EndpointSuffix=core.windows.net";


            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount)) {
                //CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                //CloudBlobContainer container = cloudBlobClient.GetContainerReference("test");
                //container.CreateIfNotExists();


                //CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference("configfile/training.config");
                //cloudBlockBlob.UploadFromFile("D:\\Source\\Training\\msft-training\\AzureStorageConsole\\AzureStorageConsole\\App.config");

                CloudTableClient client = storageAccount.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("table");
                table.CreateIfNotExists();

                Training trainingitem = new Training();
                trainingitem.PartitionKey = "2";
                trainingitem.RowKey = "4";
                trainingitem.TrainingTest = "TrainingTest";
                trainingitem.Naam = "Naam";

                TableOperation operation = TableOperation.Insert(trainingitem);
                table.Execute(operation);
            }
        }
    }
}
