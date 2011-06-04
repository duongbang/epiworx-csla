namespace Epiworx.Data
{
    public interface ICategoryDataFactory
    {
        CategoryData Fetch(CategoryDataCriteria criteria);
        CategoryData[] FetchInfoList(CategoryDataCriteria criteria);
        CategoryData Update(CategoryData data);
        CategoryData Insert(CategoryData data);
        void Delete(CategoryDataCriteria criteria);
    }
}
