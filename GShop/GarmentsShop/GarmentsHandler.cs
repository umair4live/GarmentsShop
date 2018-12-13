using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace GShop.GarmentsShop
{
    public class GarmentsHandler
    {



        //#region departments
        public Department GetDepartment(int id)
        {
            using (GarmentsContext contex = new GarmentsContext())
            {
                return (from d in contex.Departments
                        where d.Id == id
                        select d).First();
            }
        }

        public List<Department> GetDepartments()
        {
            using (GarmentsContext contex = new GarmentsContext())
            {
                return (from d in contex.Departments
                        select d).ToList();
            }
        }

        public void AddDepartment(Department dept)
        {
            using (GarmentsContext contex = new GarmentsContext())
            {
                contex.Departments.Add(dept);
                contex.SaveChanges();
            }
        }

        public void UpdateDepartment(int idToSearch, Department dept)
        {
            using (GarmentsContext contex = new GarmentsContext())
            {
                Department found = (from d in contex.Departments
                                    where d.Id == idToSearch
                                    select d).First();
                if (!string.IsNullOrWhiteSpace(dept.Name))
                {
                    found.Name = dept.Name;
                }
                found.ImageUrl = dept.ImageUrl;
                contex.SaveChanges();
            }
        }


        public void DeleteDepartment(int idToSearch)
        {
            using (GarmentsContext contex = new GarmentsContext())
            {
                Department found = (from d in contex.Departments
                                    where d.Id == idToSearch
                                    select d).First();
                contex.Departments.Remove(found);
                contex.SaveChanges();
            }
        }

        //#endregion

        #region products
        public List<Product> GetProducts()
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from p in context.Products
                               .Include(p => p.Fabric)
                               .Include(p => p.Images)
                               .Include(p => p.ColorsOffered)
                               .Include(p => p.SizesOffered)
                               .Include(p => p.SubCategory.Category.Department)
                        select p).ToList();
            }
        }

        public List<Product> GetProducts(Category category)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from p in context.Products
                               .Include(p => p.Fabric)
                               .Include(p => p.Images)
                               .Include(p => p.ColorsOffered)
                               .Include(p => p.SizesOffered)
                               .Include(p => p.SubCategory.Category.Department)
                        where p.SubCategory.Category.Id == category.Id
                        select p).ToList();
            }
        }

        public Product GetProduct(int id)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from p in context.Products
                               .Include(p => p.Fabric)
                               .Include(p => p.Images)
                               .Include(p => p.ColorsOffered)
                               .Include(p => p.SizesOffered)
                               .Include(p => p.SubCategory.Category.Department)
                        where p.Id == id
                        select p).First();
            }
        }

        public void AddProduct(Product product)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                context.Entry(product.Fabric).State = EntityState.Unchanged;
                context.Entry(product.SubCategory).State = EntityState.Unchanged;
                foreach (var c in product.ColorsOffered)
                {
                    context.Entry(c).State = EntityState.Unchanged;
                }
                foreach (var s in product.SizesOffered)
                {
                    context.Entry(s).State = EntityState.Unchanged;
                }

                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        #endregion






        #region categories

        public List<Category> GetCategories()
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from c in context.Categories
                            .Include(c => c.Department)
                        select c).ToList();
            }
        }

        public List<Category> GetCategories(Department dept)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from c in context.Categories
                             .Include(c => c.Department)
                        where c.Department.Id == dept.Id
                        select c).ToList();
            }
        }



        public List<SubCategory> GetSubCategories(Category category)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from c in context.SubCategories
                            .Include(c => c.Category.Department)
                        where c.Category.Id == category.Id
                        select c).ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                Category found = (from c in context.Categories
                                  .Include(c => c.Department)
                                  where c.Id == id
                                  select c).FirstOrDefault();
                return found;
            }

        }


        public void AddCategory(Category category)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                context.Entry(category.Department).State = EntityState.Unchanged;
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }


        public void UpdateCategory(int id, Category category)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                Category found = context.Categories.Find(id);
                if (!string.IsNullOrWhiteSpace(category.Name)) found.Name = category.Name;
                if (!string.IsNullOrWhiteSpace(category.ImageUrl)) found.ImageUrl = category.ImageUrl;
                if (category.Department != null && category.Department.Id > 0) found.Department = category.Department;
                context.Entry(category.Department).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                Category found = context.Categories.Find(id);
                context.Categories.Remove(found);
                context.SaveChanges();
            }
        }
        #endregion


        public List<Color> GetColors()
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from c in context.Colors select c).ToList();
            }
        }



        public List<Size> GetSizes()
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from s in context.Sizes select s).ToList();
            }
        }

        public List<Fabric> GetFabrics()
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from f in context.Fabrics select f).ToList();
            }
        }


    }
}
