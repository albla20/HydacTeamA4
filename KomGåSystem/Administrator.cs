using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace KomGåSystem
{
    public class Administrator
    {
        public String UserName;
        public string PassWord;

        public Administrator(string username, string password)
        {
            this.UserName = username;
            this.PassWord = password;
        }

            
            
        

    }
}
