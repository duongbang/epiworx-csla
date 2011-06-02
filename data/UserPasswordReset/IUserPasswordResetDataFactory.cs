namespace Epiworx.Data
{
    public interface IUserPasswordResetDataFactory
    {
        UserPasswordResetData Fetch(UserPasswordResetDataCriteria criteria);
        UserPasswordResetData Update(UserPasswordResetData data);
    }
}
