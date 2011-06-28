using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class StatusRepository
    {
        public static Status StatusFetch(int statusId)
        {
            return Status.FetchStatus(
                new StatusDataCriteria
                {
                    StatusId = statusId
                });
        }

        public static StatusInfoList StatusFetchInfoList(int projectId)
        {
            ProjectUserRepository.AuthorizeProjectUser(projectId);

            return StatusInfoList.FetchStatusInfoList(
                new StatusDataCriteria
                    {
                        ProjectId = projectId
                    });
        }

        public static StatusInfoList StatusFetchInfoList(StatusDataCriteria criteria)
        {
            return StatusInfoList.FetchStatusInfoList(criteria);
        }

        public static Status StatusSave(Status status)
        {
            if (!status.IsValid)
            {
                return status;
            }

            Status result;

            if (status.IsNew)
            {
                result = StatusRepository.StatusInsert(status);
            }
            else
            {
                result = StatusRepository.StatusUpdate(status);
            }

            return result;
        }

        public static Status StatusInsert(Status status)
        {
            status = status.Save();

            SourceRepository.SourceAdd(status.StatusId, SourceType.Status, status.Name);

            FeedRepository.FeedAdd(FeedAction.Created, status);

            return status;
        }

        public static Status StatusUpdate(Status status)
        {
            ProjectUserRepository.AuthorizeProjectUser(status.ProjectId);

            status = status.Save();

            SourceRepository.SourceUpdate(status.StatusId, SourceType.Status, status.Name);

            FeedRepository.FeedAdd(FeedAction.Edited, status);

            return status;
        }

        public static Status StatusNew()
        {
            var status = Status.NewStatus();

            return status;
        }

        public static bool StatusDelete(Status status)
        {
            Status.DeleteStatus(
                new StatusDataCriteria
                {
                    StatusId = status.StatusId
                });

            FeedRepository.FeedAdd(FeedAction.Deleted, status);

            return true;
        }

        public static bool StatusDelete(int statusId)
        {
            return StatusRepository.StatusDelete(
                StatusRepository.StatusFetch(statusId));
        }
    }
}
