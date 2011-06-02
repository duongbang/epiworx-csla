namespace Epiworx.Data
{
    public interface IProjectDataFactory
    {
        ProjectData Fetch(ProjectDataCriteria criteria);
        ProjectData[] FetchInfoList(ProjectDataCriteria criteria);
        ProjectData Update(ProjectData data);
        ProjectData Insert(ProjectData data);
        void Delete(ProjectDataCriteria criteria);
    }
}
