using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ChangePassword
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string CurentPassword { get; set; }
        public string NewPassword { get; set; }
        public string Renewpassword { get; set; }
        public DateTime? RegDate { get; set; } = DateTime.Now;
        
        //public User_Picture User_Picture { get; set; }
        


    }
}
