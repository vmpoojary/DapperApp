namespace DapperApp.Repository.Interface
{
    public interface IEmployee
    {
        Task<object> GetEmployees();
        Task<object> GetEmployee(string id);
    }
}
