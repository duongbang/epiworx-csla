namespace Epiworx.Data
{
    public interface IAttachmentDataFactory
    {
        AttachmentData Fetch(AttachmentDataCriteria criteria);
        AttachmentData[] FetchInfoList(AttachmentDataCriteria criteria);
        AttachmentData Update(AttachmentData data);
        AttachmentData Insert(AttachmentData data);
        void Delete(AttachmentDataCriteria criteria);
    }
}
