using System;
using System.Collections.Generic;
using System.Text;

namespace AlsetMobileAttendence.Modal
{
    public class Login
    {
        public object body { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string newPassword { get; set; }
        public string session { get; set; }
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string IdToken { get; set; }
    }
}
