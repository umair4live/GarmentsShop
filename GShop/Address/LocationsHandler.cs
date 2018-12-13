using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GShop
{
    public class LocationsHandler
    {

        #region Country
        public Country GetCountry(int id)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from c in context.Countries
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<Country> GetCountries()
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from c in context.Countries
                        select c).ToList();
            }
        }
        public void AddCountry(Country country)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }
        }

        public void DeleteCountry(Country country)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                Country found = context.Countries.Find(country.Id);
                context.Countries.Remove(found);
                context.SaveChanges();
            }
        }

        public void UpdateCountry(int idToSearch, Country country)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                Country found = context.Countries.Find(idToSearch);
                if (!(string.IsNullOrWhiteSpace(country.Name)))
                {
                    found.Name = country.Name;
                }
                found.Code = country.Code;
                context.SaveChanges();
            }
        }
        #endregion

        #region Province


        public void AddProvince(Province province)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                context.Entry(province.Country).State = EntityState.Unchanged;
                context.Provinces.Add(province);
                context.SaveChanges();                
            }
        }

        public Province GetProvince(int id)
        {
            //Province found = null;
            using (GarmentsContext context = new GarmentsContext())
            {
                //context.Configuration.LazyLoadingEnabled = true;
                Province found = (from p in context.Provinces
                                  .Include(p=>p.Country)
                              where p.Id == id
                              select p).FirstOrDefault();
                return found;
                //string name = found.Country.Name; 
            }
        }



        public List<Province> GetProvinces(Country country)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from p in context.Provinces
                        where p.Country.Id == country.Id
                        select p).ToList();
            }
        }

        //public List<City> GetCities(Province province)
        //{
        //    using (GarmentsContext context = new GarmentsContext())
        //    {
        //        //context.Configuration.LazyLoadingEnabled = false;
        //        List<City> cities = (from c in context.Cities   
        //                             .Include(c=>c.Province.Country)
        //                             where c.Province.Id == province.Id
        //                             select c).ToList();

        //        //string s1= cities[0].Province.Name;
        //        //string s2 = cities[0].Province.Country.Name;
        //        return cities;
        //    } 

        //}
        #endregion










        //public List<City> GetCities(Country country)
        //{
        //    using (GarmentsContext context = new GarmentsContext())
        //    {
        //        return (from c in context.Cities
        //                           .Include(x=>x.Province.Country)
        //                where c.Province.Country.Id == country.Id
        //                select c).ToList();
        //    }

        //}
    }
}
