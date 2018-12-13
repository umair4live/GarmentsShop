using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarmentsShop.Models.Products
{
    public class DetailsModel
    {
        public DetailsModel()
        {
            ImageUrls = new List<string>();
            SizesOffered = new List<SizeModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public List<string> ImageUrls { get; set; }

        public List<SizeModel> SizesOffered { get; set; }
        









    }
}