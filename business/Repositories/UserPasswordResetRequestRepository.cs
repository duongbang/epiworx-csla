using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class UserPasswordResetRequestRepository
    {
        public static UserPasswordResetRequest UserPasswordResetRequestAdd(string email)
        {
            var userPasswordResetRequest = UserPasswordResetRequestRepository.UserPasswordResetRequestFetch(email);

            userPasswordResetRequest.Token = Guid.NewGuid().ToString().ToUpper().Replace("-", string.Empty);
            userPasswordResetRequest.TokenExpirationDate = DateTime.Now.AddHours(Settings.TokenExpirationNumberOfHours);

            userPasswordResetRequest = UserPasswordResetRequestRepository.UserPasswordResetRequestSave(userPasswordResetRequest);

            return userPasswordResetRequest;
        }

        private static UserPasswordResetRequest UserPasswordResetRequestFetch(string email)
        {
            return UserPasswordResetRequest.FetchUserPasswordResetRequest(
                new UserPasswordResetRequestDataCriteria
                {
                    Email = email
                });
        }

        private static UserPasswordResetRequest UserPasswordResetRequestSave(UserPasswordResetRequest userPasswordResetRequest)
        {
            if (!userPasswordResetRequest.IsValid)
            {
                return userPasswordResetRequest;
            }

            UserPasswordResetRequest result;

            result = UserPasswordResetRequestRepository.UserPasswordResetRequestUpdate(userPasswordResetRequest);

            return result;
        }

        private static UserPasswordResetRequest UserPasswordResetRequestUpdate(UserPasswordResetRequest userPasswordResetRequest)
        {
            userPasswordResetRequest = userPasswordResetRequest.Save();

            return userPasswordResetRequest;
        }
    }
}
