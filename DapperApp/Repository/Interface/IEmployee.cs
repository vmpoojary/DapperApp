namespace DapperApp.Repository.Interface
{
    public interface IEmployee
    {
        Task<object> GetEmployees();
        Task<object> GetEmployee(string id);
        Task<object> GetEmployeeO();
        Task<object>GetEmployeesO(string id);
    }
}
