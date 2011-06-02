namespace Epiworx.Data
{
    public interface IProjectUserMemberDataFactory
    {
        ProjectUserMemberData Fetch(ProjectUserMemberDataCriteria criteria);
        ProjectUserMemberData[] FetchInfoList(ProjectUserMemberDataCriteria criteria);
        ProjectUserMemberData Update(ProjectUserMemberData data);
        ProjectUserMemberData Insert(ProjectUserMemberData data);
        void Delete(ProjectUserMemberDataCriteria criteria);
    }
}
