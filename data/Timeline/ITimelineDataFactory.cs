namespace Epiworx.Data
{
    public interface ITimelineDataFactory
    {
        TimelineData Fetch(TimelineDataCriteria criteria);
        TimelineData[] FetchInfoList(TimelineDataCriteria criteria);
        TimelineData Update(TimelineData data);
        TimelineData Insert(TimelineData data);
        void Delete(TimelineDataCriteria criteria);
    }
}
