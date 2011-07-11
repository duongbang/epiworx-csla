using System;
using System.Collections.Generic;
using System.ComponentModel;
using Epiworx.Business;

namespace Epiworx.WcfRestService
{
    public class UserData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<TimelineData> Timelines { get; set; }

        public UserData()
        {
            this.Timelines = new List<TimelineData>();
        }

        public UserData(int userId, string name)
            : this(userId, name, string.Empty)
        {
        }

        public UserData(IUser user)
            : this()
        {
            this.UserId = user.UserId;
            this.Name = user.Name;
            this.Email = user.Email;
        }

        public UserData(int userId, string name, string email)
            : this()
        {
            this.UserId = userId;
            this.Name = name;
            this.Email = email;
        }
    }
}
