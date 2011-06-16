using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class AttachmentDataFactory : IAttachmentDataFactory
    {
        public AttachmentData Fetch(AttachmentDataCriteria criteria)
        {
            var data = MockDb.Attachments
                .Where(row => row.AttachmentId == criteria.AttachmentId)
                .Single();

            data = this.Fetch(data);

            return data;
        }

        public AttachmentData Fetch(AttachmentData data)
        {
            data.Source = MockDb.Sources
               .Where(row => row.SourceId == data.SourceId)
               .Single();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .Single();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .Single();

            return data;
        }

        public AttachmentData[] FetchInfoList(AttachmentDataCriteria criteria)
        {
            var query = MockDb.Attachments
                .AsQueryable();

            var attachments = query.AsQueryable();

            var data = new List<AttachmentData>();

            foreach (var attachment in attachments)
            {
                data.Add(this.Fetch(attachment));
            }

            return data.ToArray();
        }

        public AttachmentData Create()
        {
            return new AttachmentData();
        }

        public AttachmentData Update(AttachmentData data)
        {
            var attachment = MockDb.Attachments
                .Where(row => row.AttachmentId == data.AttachmentId)
                .Single();

            Csla.Data.DataMapper.Map(data, attachment);

            return data;
        }

        public AttachmentData Insert(AttachmentData data)
        {
            if (MockDb.Attachments.Count() == 0)
            {
                data.AttachmentId = 1;
            }
            else
            {
                data.AttachmentId = MockDb.Attachments.Select(row => row.AttachmentId).Max() + 1;
            }

            MockDb.Attachments.Add(data);

            return data;
        }

        public void Delete(AttachmentDataCriteria criteria)
        {
            var data = MockDb.Attachments
                .Where(row => row.AttachmentId == criteria.AttachmentId)
                .Single();

            MockDb.Attachments.Remove(data);
        }
    }
}
