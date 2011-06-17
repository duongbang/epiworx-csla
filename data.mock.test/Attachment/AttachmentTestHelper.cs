using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class AttachmentTestHelper
    {
        public static Attachment AttachmentAdd(int sourceId, SourceType sourceType)
        {
            var attachment = AttachmentTestHelper.AttachmentNew(sourceId, sourceType);

            attachment = AttachmentRepository.AttachmentSave(attachment);

            return attachment;
        }

        public static Attachment AttachmentNew(int sourceId, SourceType sourceType)
        {
            var attachment = AttachmentRepository.AttachmentNew(sourceId, sourceType);

            attachment.Name = DataHelper.RandomString(50);

            return attachment;
        }
    }
}