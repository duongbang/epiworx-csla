using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public interface IFeed
    {
		int FeedId { get; }
		string Action { get; }
		int CreatedBy { get; }
		DateTime CreatedDate { get; }
    }
}
