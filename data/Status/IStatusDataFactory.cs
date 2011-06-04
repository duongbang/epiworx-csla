namespace Epiworx.Data
{
    public interface IStatusDataFactory
    {
        StatusData Fetch(StatusDataCriteria criteria);
        StatusData[] FetchInfoList(StatusDataCriteria criteria);
        StatusData Update(StatusData data);
        StatusData Insert(StatusData data);
        void Delete(StatusDataCriteria criteria);
    }
}
