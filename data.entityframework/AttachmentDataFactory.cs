using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class AttachmentDataFactory : IAttachmentDataFactory
    {
        public AttachmentData Fetch(AttachmentDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var attachment = this.Fetch(ctx, criteria)
                    .Single();

                var attachmentData = new AttachmentData();

                this.Fetch(attachment, attachmentData);

                return attachmentData;
            }
        }

        public AttachmentData[] FetchInfoList(AttachmentDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var attachments = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var attachmentDataList = new List<AttachmentData>();

                foreach (var attachment in attachments)
                {
                    var attachmentData = new AttachmentData();

                    this.Fetch(attachment, attachmentData);

                    attachmentDataList.Add(attachmentData);
                }

                return attachmentDataList.ToArray();
            }
        }

        public AttachmentData[] FetchLookupInfoList(AttachmentDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var attachments = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var attachmentDataList = new List<AttachmentData>();

                foreach (var attachment in attachments)
                {
                    var attachmentData = new AttachmentData();

                    this.Fetch(attachment, attachmentData);

                    attachmentDataList.Add(attachmentData);
                }

                return attachmentDataList.ToArray();
            }
        }

        public AttachmentData Create()
        {
            return new AttachmentData();
        }

        public AttachmentData Update(AttachmentData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var attachment =
                    new Attachment
                    {
                        AttachmentId = data.AttachmentId
                    };

                ctx.ObjectContext.Attachments.Attach(attachment);

                DataMapper.Map(data, attachment);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public AttachmentData Insert(AttachmentData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var attachment = new Attachment();

                DataMapper.Map(data, attachment);

                ctx.ObjectContext.AddToAttachments(attachment);

                ctx.ObjectContext.SaveChanges();

                data.AttachmentId = attachment.AttachmentId;

                return data;
            }
        }

        public void Delete(AttachmentDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var attachment = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Attachments.DeleteObject(attachment);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Attachment attachment, AttachmentData attachmentData)
        {
            DataMapper.Map(attachment, attachmentData);

            attachmentData.Source = new SourceData();
            DataMapper.Map(attachment.Source, attachmentData.Source);

            attachmentData.CreatedByUser = new UserData();
            DataMapper.Map(attachment.CreatedByUser, attachmentData.CreatedByUser);

            attachmentData.ModifiedByUser = new UserData();
            DataMapper.Map(attachment.ModifiedByUser, attachmentData.ModifiedByUser);
        }

        private IQueryable<Attachment> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             AttachmentDataCriteria criteria)
        {
            IQueryable<Attachment> query = ctx.ObjectContext.Attachments
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.AttachmentId != null)
            {
                query = query.Where(row => row.AttachmentId == criteria.AttachmentId);
            }

            if (criteria.FileType != null)
            {
                query = query.Where(row => row.FileType == criteria.FileType);
            }

            if (criteria.IsArchived != null)
            {
                query = query.Where(row => row.IsArchived == criteria.IsArchived);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.SourceId != null)
            {
                query = query.Where(row => criteria.SourceId.Contains(row.SourceId));
            }

            if (criteria.SourceTypeId != null)
            {
                query = query.Where(row => row.SourceTypeId == criteria.SourceTypeId);
            }

            if (criteria.CreatedBy != null)
            {
                query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
            }

            if (criteria.CreatedDate != null
                && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null
                && (criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
            }

            if (criteria.ModifiedBy != null)
            {
                query = query.Where(row => row.ModifiedBy == criteria.ModifiedBy);
            }

            if (criteria.ModifiedDate != null
                && criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate != null
                && (criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.Text != null)
            {
                query = query.Where(row => row.Name.Contains(criteria.Text));
            }

            if (criteria.SortBy != null)
            {
                query = query.OrderBy(string.Format(
                    "{0} {1}",
                    criteria.SortBy,
                    criteria.SortOrder == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            if (criteria.SkipRecords != null)
            {
                query = query.Skip(criteria.SkipRecords.Value);
            }

            if (criteria.MaximumRecords != null)
            {
                query = query.Take(criteria.MaximumRecords.Value);
            }

            return query;
        }
    }
}
