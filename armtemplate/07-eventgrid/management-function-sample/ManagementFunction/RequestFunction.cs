using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ManagementFunction
{
    public static class RequestFunction
    {
        [FunctionName("RequestFunction")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("Request Function got triggered.");

            string name = DateTime.Now.ToString("MMddyyyyHHmmssfff") + ".json";
            
            // Get request body
            Stream reqDocument = await req.Content.ReadAsStreamAsync();
            await CreateBlob(name, reqDocument, log);
            
            return req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }

        private async static Task CreateBlob(string name, Stream data, TraceWriter log) {
            string connectionString;
            CloudStorageAccount storageAccount;
            CloudBlobClient client;
            CloudBlobContainer container;
            CloudBlockBlob blob;

            connectionString = GetEnvironmentVariable("StorageConnectionAppSetting");
            storageAccount = CloudStorageAccount.Parse(connectionString);

            client = storageAccount.CreateCloudBlobClient();

            container = client.GetContainerReference("requestdocuments");
            await container.CreateIfNotExistsAsync();

            blob = container.GetBlockBlobReference(name);
            blob.Properties.ContentType = "application/json";

            await blob.UploadFromStreamAsync(data);
        }

        public static string GetEnvironmentVariable(string name) {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
