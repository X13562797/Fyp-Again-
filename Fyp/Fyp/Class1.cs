using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace Fyp
{
    public class Class1 : TableEntity
    {
        public Class1(string category, string sku) : base(category, sku)
        {

        }
        public Class1() { }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}