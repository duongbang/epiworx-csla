namespace Epiworx.Data
{
    public interface ISourceTypeDataFactory
    {
        SourceTypeData Fetch(SourceTypeDataCriteria criteria);
        SourceTypeData[] FetchInfoList(SourceTypeDataCriteria criteria);
    }
}
