using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace DAL
{

    public class Login_User_DAL
    {
        DB_Support db = new DB_Support();

        public byte Login(string username, string password, string repassword)
        {


            if (db.Users.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (db.Users.Any(i => i.UserName == username && i.Password == password && i.Repassword == repassword))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
        public bool Read(User_Login u)
        {
            return db.Users.Any(i => i.Password == u.Password && i.UserName == u.UserName);
        }
        public User_Login Read(int id)
        {
            return db.Users.Where(i => i.id == id).SingleOrDefault();
        }
        public List<User_Login> Read()
        {
            return db.Users.ToList();
        }
       
        bool flag = true;
        public void Register(User_Login u)
        {
            if (!Read(u))
            {

                if (u.Password.Length >= 8 && u.Password == u.Repassword)
                {
                    if (flag)
                    {
                        db.Users.Add(u);
                        db.SaveChanges();
                    }

                                        

                    else if (!flag)
                    {

                    }

                }


            }


        }
                              

    }
}

    




