using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GarmentsShop.Models.Products
{
    public class ByCategoryModel
    {
        public ByCategoryModel()
        {
            Products = new List<SummaryModel>();
        }

        public string CategoryName { get; set; }
        public List<SummaryModel> Products { get; set; }

    }
}