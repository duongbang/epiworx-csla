namespace Epiworx.Data
{
    public interface IOrganizationUserMemberDataFactory
    {
        OrganizationUserMemberData Fetch(OrganizationUserMemberDataCriteria criteria);
        OrganizationUserMemberData[] FetchInfoList(OrganizationUserMemberDataCriteria criteria);
        OrganizationUserMemberData Update(OrganizationUserMemberData data);
        OrganizationUserMemberData Insert(OrganizationUserMemberData data);
        void Delete(OrganizationUserMemberDataCriteria criteria);
    }
}
