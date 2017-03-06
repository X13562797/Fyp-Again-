using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;


    namespace Fyp
    {
        public partial class WebForm4 : System.Web.UI.Page
        {

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // Getting the data from th App config file

            string connstring = ConfigurationManager.ConnectionStrings["AzureStorageConn"].ConnectionString;

            string localFolder = ConfigurationManager.AppSettings["sourceFolder"];

            //Creating the blob storage account

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstring);

            //creating blob client

            CloudBlobClient client = storageAccount.CreateCloudBlobClient();

            //creating container

            CloudBlobContainer container = client.GetContainerReference("fyp11");

            container.CreateIfNotExists();

            //code for uploding the data to the cloud

            string[] fileEntries = Directory.GetFiles(localFolder);

            foreach (string filePath in fileEntries)
            {
                string key = Path.GetFileName(filePath);

                CloudBlockBlob blob = container.GetBlockBlobReference(key);

                using (var fs = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    blob.UploadFromStream(fs);
                }
            }

            label1.Text = "Successfully Uploaded the Data";

            // Place the connections string of the blob storage 
        }
    }
}
