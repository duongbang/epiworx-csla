namespace Epiworx.Data
{
    public interface IUserDataFactory
    {
        UserData Fetch(UserDataCriteria criteria);
        UserData[] FetchInfoList(UserDataCriteria criteria);
        UserData[] FetchLookupInfoList(UserDataCriteria criteria);
        UserData Update(UserData data);
        UserData Insert(UserData data);
        void Delete(UserDataCriteria criteria);
    }
}
