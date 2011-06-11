namespace Epiworx.Data
{
    public interface IStoryDataFactory
    {
        StoryData Fetch(StoryDataCriteria criteria);
        StoryData[] FetchInfoList(StoryDataCriteria criteria);
        StoryData Update(StoryData data);
        StoryData Insert(StoryData data);
        void Delete(StoryDataCriteria criteria);
    }
}
