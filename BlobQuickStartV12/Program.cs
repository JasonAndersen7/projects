using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;

namespace BlobQuickStartV12
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            string containerName = "certscompbu-prd-blob-eu2-01";
            double count =0;
            Console.WriteLine("Azure Blob storage v12 - .NET quickstart sample\n");

            // Retrieve the connection string for use with the application. The storage
            // connection string is stored in an environment variable on the machine
            // running the application called AZURE_STORAGE_CONNECTION_STRING. If the
            // environment variable is created after the application is launched in a
            // console or with Visual Studio, the shell or application needs to be closed
            // and reloaded to take the environment variable into account.
            //string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

            string connectionString ="DefaultEndpointsProtocol=https;AccountName=certscompbuprdeu2sa1;AccountKey=P0LXyJav9ubcSzuWAJflLhdSzqgIuFDokpFywMx2jCVzHh9LFLn3ttDInJIE2OJ1xmRSWj/rPzsBUATO0ow5cw==;EndpointSuffix=core.windows.net";


            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            Console.WriteLine("Listing blobs...");

            // List all blobs in the container
            
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                //Console.WriteLine("\t" + blobItem.Name);

                count++;
            }

            Console.WriteLine("Blob count:" + count + " " + DateTime.Now.ToUniversalTime());
            Console.Read();
        }
    }
}
