namespace Epiworx.Data
{
    public interface IUserPasswordResetRequestDataFactory
    {
        UserPasswordResetRequestData Fetch(UserPasswordResetRequestDataCriteria criteria);
        UserPasswordResetRequestData Update(UserPasswordResetRequestData data);
    }
}
