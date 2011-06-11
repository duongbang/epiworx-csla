using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class AttachmentRepository
    {
        public static Attachment AttachmentFetch(int attachmentId)
        {
            return Attachment.FetchAttachment(
                new AttachmentDataCriteria
                {
                    AttachmentId = attachmentId
                });
        }

        public static AttachmentInfoList AttachmentFetchInfoList(AttachmentDataCriteria criteria)
        {
            return AttachmentInfoList.FetchAttachmentInfoList(criteria);
        }

        public static Attachment AttachmentSave(Attachment attachment)
        {
            if (!attachment.IsValid)
            {
                return attachment;
            }

            Attachment result;

            if (attachment.IsNew)
            {
                result = AttachmentRepository.AttachmentInsert(attachment);
            }
            else
            {
                result = AttachmentRepository.AttachmentUpdate(attachment);
            }

            return result;
        }

        public static Attachment AttachmentInsert(Attachment attachment)
        {
            attachment = attachment.Save();

            return attachment;
        }

        public static Attachment AttachmentUpdate(Attachment attachment)
        {
            attachment = attachment.Save();

            return attachment;
        }

        public static Attachment AttachmentNew()
        {
            var attachment = Attachment.NewAttachment();

            return attachment;
        }

        public static bool AttachmentDelete(Attachment attachment)
        {
            Attachment.DeleteAttachment(
                new AttachmentDataCriteria
                {
                    AttachmentId = attachment.AttachmentId
                });

            return true;
        }

        public static bool AttachmentDelete(int attachmentId)
        {
            return AttachmentRepository.AttachmentDelete(
                AttachmentRepository.AttachmentFetch(attachmentId));
        }
    }
}
