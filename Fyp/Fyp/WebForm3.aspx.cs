using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace Fyp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string accountname = "fyp11";
            string accountkey = "lpodP39hyFl9dxBfg7ph35HghC+doOsd+KUeriajd++hQ2sJsk2pthH42rGkqcJN+i1W/CWgXXt0BeY/2/hmOg==";
            try
            {
                StorageCredentials creds = new StorageCredentials(accountname, accountkey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                CloudTableClient client = account.CreateCloudTableClient();
                CloudTable table = client.GetTableReference("sportingproducts");
                table.CreateIfNotExists();
                //PRIMARY KEY
                Class1 entity = new Class1("baseball", "81011")
                {
                    ProductName = "Louisville Slugger",
                    Description = " A great bat for any level of player"
                };

                TableOperation insertOperation = TableOperation.Insert(entity);
                table.Execute(insertOperation);

            }

            catch (Exception ex)
            {

            }


        }
    }
}
