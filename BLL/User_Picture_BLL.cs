using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using DAL;

namespace BLL
{
    public class User_Picture_BLL
    {
        User_Picture_DAL DAL= new User_Picture_DAL();
        Login_User_DAL dal = new Login_User_DAL();
        public byte Login(string username, string password,string repassword)
        {
            return dal.Login(username, Encode(password), Encode(repassword));
        }
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
        
        public void Register(User_Login u)
        {
            // Encode(u.Password);
            u.Password = Encode(u.Password);
            u.Repassword = Encode(u.Repassword);
            dal.Register(u);
        }
        
        public string Update(int id, User_Login unew)
        {
           return DAL.Update(id, unew);
        }
        public string Delete(int id)
        {
            return DAL.Delete(id);
        }
    }
}
