using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kanema.Models
{
    public class AccountValidator
    {
        public bool VerifyData(string login, string password, string confirmPassword) => VerifyLogin(login) && VerifyPassword(password) && VerifyConfirmPassword(password, confirmPassword);

        public bool VerifyLogin(string login)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }
            Regex reg = new Regex("[A-Za-z0-9_]{4,20}");
            Match match = reg.Match(login);
            return match.Success && login.Length <= 20;
        }

        public bool CheckIsEmpty(string str)
        {
            return str.Length != 0;
        }

        public bool CheckForDigits(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str == "" || !Char.IsDigit(str[i]))
                    return true;
            }
            return false;
        }

        //    Regex reg = new Regex("[A-Za-z0-9_]{4,20}");
        //    Match match = reg.Match(login);

        //    return match.Success && login.Length <= 20;
        //}

        public bool VerifyPassword(string password)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            Regex reg = new Regex("[A-Za-z0-9_]{6,20}");
            Match match = reg.Match(password);
            return match.Success && password.Length <= 20;
        }

        public bool VerifyConfirmPassword(string password, string confirmpassword)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (confirmpassword is null)
            {
                throw new ArgumentNullException(nameof(confirmpassword));
            }

            bool result = password.Equals(confirmpassword);

            return result;
        }

        //public static bool CheckForRussionLetters(string letters)
        //{
        //    var result = false;
        //    return result;
        //}
    }
}
