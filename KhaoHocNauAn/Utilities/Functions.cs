﻿using System.Security.Cryptography;
using System.Text;

namespace KhoaHocNauAn.Utilities
{
    public class Functions
    {
		public static int _CustomerID = 0;
		public static string _CustomerName = string.Empty;
		public static string _Email = string.Empty;
		public static int _Phone = 0;
		public static string _Message = string.Empty;
		public static string _MessageEmail = string.Empty;
		public static string TitleSlugGeneration(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }
        public static string Date()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string MD5Hash(string text)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
			byte[] result = md5.Hash;
			StringBuilder strBuilder = new StringBuilder();
			for (int i = 0; i < result.Length; i++)
			{
				strBuilder.Append(result[i].ToString("x2"));
			}
			return strBuilder.ToString();
		}
		public static string MD5Password(string? text)
		{
			string str = MD5Hash(text);
			for (int i = 0; i <= 5; i++)
				str = MD5Hash(str + "_" + str);
			return str;
		}
		public static bool IsLogin()
		{
			if (string.IsNullOrEmpty(Functions._CustomerName) || string.IsNullOrEmpty(Functions._Email) || (Functions._CustomerID <= 0))
				return false;
			return true;
		}
	}
}
