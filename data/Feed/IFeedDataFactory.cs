namespace Epiworx.Data
{
    public interface IFeedDataFactory
    {
        FeedData Fetch(FeedDataCriteria criteria);
        FeedData[] FetchInfoList(FeedDataCriteria criteria);
        FeedData Update(FeedData data);
        FeedData Insert(FeedData data);
        void Delete(FeedDataCriteria criteria);
    }
}
