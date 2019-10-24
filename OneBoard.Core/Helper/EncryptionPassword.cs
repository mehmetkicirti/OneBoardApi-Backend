using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OneBoard.Core.Helper
{
   public class EncryptionPassword
    {

        #region RemoveEncryptProcess
        public static string EncryptPassword(string password)
        {
            if (password == "" || password == null)
                throw new ArgumentNullException("There is no content to encrypt.");

            SHA256Managed pwd = new SHA256Managed();
            byte[] aryPassword = ConvertToByte(password);
            byte[] aryHash = pwd.ComputeHash(aryPassword);

            return BitConverter.ToString(aryHash);
        }
        public static byte[] ConvertToByte(string value)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetBytes(value);
        }

        //public static string DecryptPassword(string decodePwd)
        //{
        //    if (decodePwd == "" || decodePwd == null)
        //        throw new ArgumentNullException("There is no content to decrypt.");

        //    SHA256Managed encryptPwd = new SHA256Managed();
        //    encryptPwd.
        //}

        #endregion

    }
}
