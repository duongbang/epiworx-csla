namespace Epiworx.Data
{
    public interface IOrganizationDataFactory
    {
        OrganizationData Fetch(OrganizationDataCriteria criteria);
        OrganizationData[] FetchInfoList(OrganizationDataCriteria criteria);
        OrganizationData Update(OrganizationData data);
        OrganizationData Insert(OrganizationData data);
        void Delete(OrganizationDataCriteria criteria);
    }
}
