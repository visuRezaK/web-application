using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User_Login
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
        public string Pic { get; set; }
        public string Status { get; set; }
        public DateTime? RegDate { get; set; } = DateTime.Now;
        public List<Invoice> invoices { get; set; }=new List<Invoice>();
        public List<Report> Reports { get; set; } =new List<Report>();
       // public ChangePassword ChangePassword { get; set; }
        public List<User_Picture> user_Pictures { get; set; }
    }
}
