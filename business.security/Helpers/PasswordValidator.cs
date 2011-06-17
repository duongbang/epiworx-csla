using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Epiworx.Business.Security.Helpers
{
    public class PasswordValidator : IPasswordValidator
    {
        private const string ValidationExpression = @"((?=.*\d).{6,30})";

        public bool Validate(string password)
        {
            var match = Regex.Match(
                password,
                PasswordValidator.ValidationExpression,
                RegexOptions.IgnoreCase);

            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}
