namespace Epiworx.Data
{
    public interface IFilterDataFactory
    {
        FilterData Fetch(FilterDataCriteria criteria);
        FilterData[] FetchInfoList(FilterDataCriteria criteria);
        FilterData Update(FilterData data);
        FilterData Insert(FilterData data);
        void Delete(FilterDataCriteria criteria);
    }
}
