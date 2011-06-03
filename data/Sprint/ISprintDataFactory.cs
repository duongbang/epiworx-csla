namespace Epiworx.Data
{
    public interface ISprintDataFactory
    {
        SprintData Fetch(SprintDataCriteria criteria);
        SprintData[] FetchInfoList(SprintDataCriteria criteria);
        SprintData Update(SprintData data);
        SprintData Insert(SprintData data);
        void Delete(SprintDataCriteria criteria);
    }
}
