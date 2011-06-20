using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Business.Helpers
{
    public class DataHelper
    {
        public static string FetchRoleName(int roleId)
        {
            switch ((Role)roleId)
            {
                case Role.Collaborator:
                    return "Collaborator";
                case Role.None:
                    return "None";
                case Role.Owner:
                    return "Owner";
                case Role.Reviewer:
                    return "Reviewer";
                default:
                    throw new NotImplementedException();
            }
        }

        public static string FetchSourceTypeName(int sourceTypeId)
        {
            switch ((SourceType)sourceTypeId)
            {
                case SourceType.Attachment:
                    return "Attachment";
                case SourceType.Category:
                    return "Category";
                case SourceType.Hour:
                    return "Hour";
                case SourceType.None:
                    return "None";
                case SourceType.Note:
                    return "Note";
                case SourceType.Project:
                    return "Project";
                case SourceType.ProjectUser:
                    return "ProjectUser";
                case SourceType.User:
                    return "User";
                case SourceType.Sprint:
                    return "Sprint";
                case SourceType.Status:
                    return "Status";
                case SourceType.Story:
                    return "Story";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
