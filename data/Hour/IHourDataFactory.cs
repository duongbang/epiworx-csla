namespace Epiworx.Data
{
    public interface IHourDataFactory
    {
        HourData Fetch(HourDataCriteria criteria);
        HourData[] FetchInfoList(HourDataCriteria criteria);
        HourData Update(HourData data);
        HourData Insert(HourData data);
        void Delete(HourDataCriteria criteria);
    }
}
