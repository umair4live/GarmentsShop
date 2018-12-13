using GarmentsShop.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarmentsShop.Models
{
    public class MenuModel
    {
        public MenuModel()
        {
            Categories = new List<CategoryModel>();
        }

        public string DepartmentName { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}