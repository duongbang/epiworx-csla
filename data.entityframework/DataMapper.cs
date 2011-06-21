﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class DataMapper
    {
        internal static void Map(Project source, ProjectData destination)
        {
            destination.ProjectId = source.ProjectId;
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.IsArchived = source.IsArchived;
            destination.IsActive = source.IsActive;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(ProjectData source, Project destination)
        {
            destination.ProjectId = source.ProjectId;
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.IsArchived = source.IsArchived;
            destination.IsActive = source.IsActive;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
        }

        internal static void Map(ProjectUserMember source, ProjectUserMemberData destination)
        {
            destination.ProjectUserMemberId = source.ProjectUserMemberId;
            destination.ProjectId = source.ProjectId;
            destination.UserId = source.UserId;
            destination.RoleId = source.RoleId;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(ProjectUserMemberData source, ProjectUserMember destination)
        {
            destination.ProjectUserMemberId = source.ProjectUserMemberId;
            destination.ProjectId = source.ProjectId;
            destination.UserId = source.UserId;
            destination.RoleId = source.RoleId;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
        }

        internal static void Map(Source source, SourceData destination)
        {
            destination.SourceId = source.SourceId;
            destination.SourceTypeId = source.SourceTypeId;
            destination.Name = source.Name;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(SourceData source, Source destination)
        {
            destination.SourceId = source.SourceId;
            destination.SourceTypeId = source.SourceTypeId;
            destination.Name = source.Name;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(Sprint source, SprintData destination)
        {
            destination.SprintId = source.SprintId;
            destination.CompletedDate = source.CompletedDate;
            destination.IsActive = source.IsActive;
            destination.IsArchived = source.IsArchived;
            destination.IsCompleted = source.IsCompleted;
            destination.Duration = source.Duration;
            destination.EstimatedCompletedDate = source.EstimatedCompletedDate;
            destination.EstimatedDuration = source.EstimatedDuration;
            destination.Name = source.Name;
            destination.ProjectId = source.ProjectId;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(SprintData source, Sprint destination)
        {
            destination.SprintId = source.SprintId;
            destination.CompletedDate = source.CompletedDate;
            destination.IsActive = source.IsActive;
            destination.IsArchived = source.IsArchived;
            destination.IsCompleted = source.IsCompleted;
            destination.Duration = source.Duration;
            destination.EstimatedCompletedDate = source.EstimatedCompletedDate;
            destination.EstimatedDuration = source.EstimatedDuration;
            destination.Name = source.Name;
            destination.ProjectId = source.ProjectId;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(Status source, StatusData destination)
        {
            destination.StatusId = source.StatusId;
            destination.Description = source.Description;
            destination.IsActive = source.IsActive;
            destination.IsArchived = source.IsArchived;
            destination.IsCompleted = source.IsCompleted;
            destination.IsStarted = source.IsStarted;
            destination.Name = source.Name;
            destination.Ordinal = source.Ordinal;
            destination.ProjectId = source.ProjectId;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(StatusData source, Status destination)
        {
            destination.StatusId = source.StatusId;
            destination.Description = source.Description;
            destination.IsActive = source.IsActive;
            destination.IsArchived = source.IsArchived;
            destination.IsCompleted = source.IsCompleted;
            destination.IsStarted = source.IsStarted;
            destination.Name = source.Name;
            destination.Ordinal = source.Ordinal;
            destination.ProjectId = source.ProjectId;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
        }

        internal static void Map(Story source, StoryData destination)
        {
            destination.StoryId = source.StoryId;
            destination.AssignedTo = source.AssignedTo;
            destination.AssignedDate = source.AssignedDate;
            destination.CompletedDate = source.CompletedDate;
            destination.Description = source.Description;
            destination.Duration = source.Duration;
            destination.EstimatedCompletedDate = source.EstimatedCompletedDate;
            destination.EstimatedDuration = source.EstimatedDuration;
            destination.IsArchived = source.IsArchived;
            destination.IsCompleted = source.IsCompleted;
            destination.ProjectId = source.ProjectId;
            destination.SprintId = source.SprintId;
            destination.StartDate = source.StartDate;
            destination.StatusId = source.StatusId;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
        }

        internal static void Map(StoryData source, Story destination)
        {
            destination.StoryId = source.StoryId;
            destination.AssignedTo = source.AssignedTo;
            destination.AssignedDate = source.AssignedDate;
            destination.CompletedDate = source.CompletedDate;
            destination.Description = source.Description;
            destination.Duration = source.Duration;
            destination.EstimatedCompletedDate = source.EstimatedCompletedDate;
            destination.EstimatedDuration = source.EstimatedDuration;
            destination.IsArchived = source.IsArchived;
            destination.IsCompleted = source.IsCompleted;
            destination.ProjectId = source.ProjectId;
            destination.SprintId = source.SprintId;
            destination.StartDate = source.StartDate;
            destination.StatusId = source.StatusId;
            destination.ModifiedBy = source.ModifiedBy;
            destination.ModifiedDate = source.ModifiedDate;
            destination.CreatedBy = source.CreatedBy;
            destination.CreatedDate = source.CreatedDate;
        }

        internal static void Map(User source, UserData destination)
        {
            destination.UserId = source.UserId;
            destination.Name = source.Name;
            destination.Email = source.Email;
            destination.Salt = source.Salt;
            destination.Password = source.Password;
            destination.Token = source.Token;
            destination.TokenExpirationDate = source.TokenExpirationDate;
            destination.IsActive = source.IsActive;
            destination.ModifiedDate = source.ModifiedDate;
            destination.CreatedDate = source.CreatedDate;
        }

        internal static void Map(UserData source, User destination)
        {
            destination.UserId = source.UserId;
            destination.Name = source.Name;
            destination.Email = source.Email;
            destination.Salt = source.Salt;
            destination.Password = source.Password;
            destination.Token = source.Token;
            destination.TokenExpirationDate = source.TokenExpirationDate;
            destination.IsActive = source.IsActive;
            destination.ModifiedDate = source.ModifiedDate;
            destination.CreatedDate = source.CreatedDate;
        }
    }
}