using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GShop.UsersMgt
{
    public class UsersHandler
    {
        public List<User> GetUsers()
        {
            GarmentsContext context = new GarmentsContext();            
            using (context)
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        select u).ToList();                
            }
        }

        public User GetUser(string loginid, string password)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        where u.LoginId.Equals(loginid) && u.Password.Equals(password)
                        select u).FirstOrDefault();
            }
        }
        //User For Cookies
        public User GetUserForCookie(string loginid, string password)
        {
            using (GarmentsContext context = new GarmentsContext())
            {
                return (from u in context.Users
                        .Include("Role")
                        .Include("Address.City.Province.Country")
                        where u.LoginId.Equals(loginid) && u.Password.Equals(password)
                        select u).FirstOrDefault();
            }
        }

        public List<Role> GetRoles()
        {
            GarmentsContext context = new GarmentsContext();
            using (context)
            {
                return (from u in context.Roles
                        select u).ToList();
            }
        }

        //Add new User
        public void AddUser(User user)
        {
            using (GarmentsContext context= new GarmentsContext())
            {
                if (user!=null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }

        // Get Email exist

        public User GetEmailExist(Object value)
        {
            using (GarmentsContext context=new GarmentsContext())
            {
                return (from c in context.Users
                        where c.Email.Equals(value.ToString(),StringComparison.CurrentCultureIgnoreCase)
                        select c).FirstOrDefault();
            }
        }
        //Update User

        public void UpdateUser(User UserUP)
        {
            using (GarmentsContext context=new GarmentsContext())
            {
                context.Entry(UserUP).State = EntityState.Modified;
                context.SaveChanges();

            }
        }

      
    }
}
