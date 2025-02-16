using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User_Picture
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }  
        public string email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
        public string PictureAddress { get; set; }
      //  public ChangePassword ChangePassword { get; set; }
        public User_Login User_Login { get; set; }

    }
}
