using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    public class User_Picture_DAL
    {
        DB_Support db=new DB_Support();
        

        public byte Login(string username, string password,string repassword)
        {


            if (db.Users.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (db.Users.Any(i => i.UserName == username && i.Password == password))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
        public void Register(User_Login u)
        {
            if (!Read(u))
            {
               if (u.Password.Length >= 8 && u.Password == u.Repassword)
                {
                    db.Users.Add(u);
                    db.SaveChanges();
                    
                }
                else
                {
                     
                }
                
            }
            
           

        }
        public bool Read(User_Login u)
        {
            return db.Users.Any(i => i.Password == u.Password && i.Repassword == u.Repassword);
        }
        public List<User_Login> Read()
        {
            return db.Users.ToList();
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
           
            if (unew.Password.Length >= 8 && unew.Password == unew.Repassword)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return "Update information has completed successfully";
            }
            else
            {
                return "Lengh password has to be more than 8 carachters!";
            }

        }
        public string Delete(int id)
        {
            User_Login u = Read(id);
           
            db.Users.Remove(u);
            db.SaveChanges();
            return "Delete information has completed successfully";
        }
    }
}
