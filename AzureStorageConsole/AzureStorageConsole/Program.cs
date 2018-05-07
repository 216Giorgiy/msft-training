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
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagetraining02;AccountKey=G8DWbjxZrQ0Fh25UhkHQaw4tRCkT1ttwCzQEKfblym5pI0gRa+43pZqyqy980tIQYl5mJMLIssZYb3dDCPoPRA==;EndpointSuffix=core.windows.net";


            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount)) {
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = cloudBlobClient.GetContainerReference("test");
                container.CreateIfNotExists();


                CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference("configfile/training.config");
                cloudBlockBlob.UploadFromFile("C:\\AzureStorageConsole.exe.config");

                CloudTableClient client = storageAccount.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("table");
                table.CreateIfNotExists();

                Training trainingitem = new Training();
                trainingitem.PartitionKey = "2";
                trainingitem.RowKey = "3";
                trainingitem.TrainingTest = "TrainingTest";

                TableOperation operation = TableOperation.Insert(trainingitem);
                table.Execute(operation);
            }
        }
    }
}
