using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class change_password_DAL
    {
        DB_Support db = new DB_Support();
        
       public List<User_Login> Read()
        {
            return db.Users.ToList();
        }
        public bool Read(User_Login u)
        {
            return db.Users.Any(i => i.Password == u.Repassword && i.Repassword == u.Repassword);
        }
        public User_Login Read(int id)
        {
            return db.Users.Where(i => i.id == id).SingleOrDefault();
        }
        public string Update(int id, User_Login unew)
        {
            User_Login u = new User_Login();
           

                u = Read(id);
                u.Name = unew.Name;
                u.UserName = unew.UserName;
                u.Password = unew.Password;
                u.Repassword = unew.Repassword;

           
                   
                          
                         
                    db.SaveChanges();
                    return "Your password has been changed successfully.done";
              
                                 

        }
    }
}