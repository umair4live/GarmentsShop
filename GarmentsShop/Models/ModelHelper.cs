using GarmentsShop.Models.Categories;
using GarmentsShop.Models.Products;
using System;
using GShop.GarmentsShop;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarmentsShop.Models
{
    public static class ModelHelper
    {
        public static DetailsModel ToDetailsModel(this Product entity)
        {
            DetailsModel model = new DetailsModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Price = entity.Price;
            model.Description = entity.Description;
            foreach (var pImage in entity.Images)
            {
                model.ImageUrls.Add(pImage.Url);
            }
            foreach (var size in entity.SizesOffered)
            {
                model.SizesOffered.Add(new SizeModel { Id = size.Id , Name = size.Name });
            }
            return model;
        }

        public static SummaryModel ToSummaryModel(this Product entity)
        {
            SummaryModel model = new SummaryModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Price = entity.Price;
            if (entity.Images.Count > 0)
            {
                model.ImageUrl = entity.Images.First().Url;
            }
            else
            {
                model.ImageUrl = "/images/products/nophoto.png";
            }
            return model;
        }

        public static List<SummaryModel> ToSummaryModelList(this List<Product> entitiesList)
        {
            List<SummaryModel> modelsList = new List<SummaryModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToSummaryModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }


        public static List<MenuModel> ToMenuModelList(this List<Department> departments)
        {
            List<MenuModel> modelList = new List<MenuModel>();
            foreach (var d in departments)
            {
                MenuModel m = new MenuModel { DepartmentName = d.Name };
                List<Category> categories = new GarmentsHandler().GetCategories(d);
                foreach (var c in categories)
                {
                    m.Categories.Add(new CategoryModel { Id = c.Id, Name = c.Name });
                }
                m.Categories.TrimExcess();
                modelList.Add(m);
            }
            modelList.TrimExcess();
            return modelList;
        } 

        public static ByCategoryModel ToByCategoryModel(this Category category)
        {
            ByCategoryModel model = new ByCategoryModel();
            model.CategoryName = category.Name;
            model.Products = new GarmentsHandler().GetProducts(category).ToSummaryModelList();
            return model;
        }
    }
}