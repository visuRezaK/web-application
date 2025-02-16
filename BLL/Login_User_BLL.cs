using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class Login_User_BLL
    {
        Login_User_DAL dal = new Login_User_DAL();
        
        
        private string Encode(string Pass)
        {
            try
            {
                byte[] enData_byte = new byte[Pass.Length];
                enData_byte = Encoding.UTF8.GetBytes(Pass);
                string encodeData = Convert.ToBase64String(enData_byte);
                return encodeData;
            }
            catch (Exception e)
            {

                return " There is a issue,Please check it!:\n" + e.Message;
            }

        }

        //Decode For Pass
        private string Decode(string EncodePass)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder decoder = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(EncodePass);
            int charCount = decoder.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] charArray = new char[charCount];
            decoder.GetChars(todecode_byte, 0, todecode_byte.Length, charArray, 0);
            string result = new string(charArray);
            return result;
        }
        public bool Read(User_Login u)
        {
            return dal.Read(u);
        }
        public List<User_Login> Read()
        {
            return dal.Read();
        }

        public User_Login Read(int id)
        {
            return dal.Read(id);
        }
        public byte Login(string username, string password,string repassword)
        {
            return dal.Login(username,Encode( password),Encode(repassword));
        }
        
        public void Register(User_Login u)
        {
            Encode(u.Password);
            u.Password = Encode(u.Password);
            u.Repassword = Encode(u.Repassword);
            dal.Register(u);
        }
       
    }
}
  
   

