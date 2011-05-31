using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IUser
    {
        int UserId { get; }
        string Email { get; }
        string FullName { get; }
        bool IsActive { get; }
        bool IsArchived { get; }
        string Name { get; }
        string Salt { get; }
        string Password { get; }
        DateTime CreatedDate { get; }
        DateTime ModifiedDate { get; }
    }
}
