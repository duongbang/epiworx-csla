namespace Epiworx.Data
{
    public interface IUserPasswordDataFactory
    {
        UserPasswordData Fetch(UserPasswordDataCriteria criteria);
        UserPasswordData Update(UserPasswordData data);
    }
}
