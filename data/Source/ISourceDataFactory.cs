namespace Epiworx.Data
{
    public interface ISourceDataFactory
    {
        SourceData Fetch(SourceDataCriteria criteria);
        SourceData[] FetchInfoList(SourceDataCriteria criteria);
        SourceData Update(SourceData data);
        SourceData Insert(SourceData data);
        void Delete(SourceDataCriteria criteria);
    }
}
