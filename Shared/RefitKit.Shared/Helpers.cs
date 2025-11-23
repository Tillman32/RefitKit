using System;
using System.Collections.Generic;
using System.Text;

namespace RefitKit.Shared
{
    public static class Helpers
    {
        public static string Base64EncodeCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("Username or Password are empty.");

            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        }
    }
}
