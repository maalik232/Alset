using System;
using System.Collections.Generic;
using System.Text;

namespace AlsetMobileAttendence.Helper
{
    public class Constents
    {
        public struct ClassesURL
        {
            public const string GetClasses = "get-classes";
        }

        public struct ModulesURL
        {
            public const string GetModules = "get-modules";
        }

        public struct LoginURL
        {
            public const string Login = "signin-cognito";
            public const string ResetPassword = "newpwreq-cognito";
        }

        public struct FaceURL
        {
            public const string GeneratePresigned = "generate-presigned-url";
        }

    }
}
