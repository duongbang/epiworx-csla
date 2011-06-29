namespace Epiworx.Data
{
    public interface IWeekDataFactory
    {
        WeekData Fetch(WeekDataCriteria criteria);
        WeekData[] FetchInfoList(WeekDataCriteria criteria);
        WeekData Update(WeekData data);
        WeekData Insert(WeekData data);
        void Delete(WeekDataCriteria criteria);
    }
}
