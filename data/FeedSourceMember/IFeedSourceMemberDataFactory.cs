namespace Epiworx.Data
{
    public interface IFeedSourceMemberDataFactory
    {
        FeedSourceMemberData[] Fetch(FeedData parentData);
        FeedSourceMemberData Update(FeedSourceMemberData data);
        FeedSourceMemberData Insert(FeedSourceMemberData data);
        void Delete(FeedSourceMemberDataCriteria criteria);
    }
}
