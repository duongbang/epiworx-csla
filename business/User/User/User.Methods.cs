using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class User
    {
        public override string ToString()
        {
            return string.Format("{0}", this.FullName);
        }

        public UserInfo ToUserInfo()
        {
            var result = new UserInfo();

            Csla.Data.DataMapper.Map(this, result);

            return result;
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        public void SetPassword(string password)
        {
            var passwordValidator = new PasswordValidator();

            if (!passwordValidator.Validate(password))
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Salt = PasswordHelper.GetSalt(User.SaltSize);
            this.Password = PasswordHelper.Salt(this.Salt, password);
        }

        internal static User NewUser()
        {
            return Csla.DataPortal.Create<User>();
        }

        internal static User FetchUser(UserDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<User>(criteria);
        }

        internal static User FetchUser(UserData data)
        {
            var result = new User();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }
    }
}
