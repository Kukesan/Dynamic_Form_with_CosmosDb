using Dynamic_Form_with_CosmosDb.Models;

namespace Dynamic_Form_with_CosmosDb.Service
{
    public interface IEmployeeCreatedFormService
    {
        Task<List<EmployeeCreatedForm>> Get(string query);
        Task<EmployeeCreatedForm> Add(EmployeeCreatedForm employeeCreatedForm);
        Task<EmployeeCreatedForm> Update(EmployeeCreatedForm employeeCreatedForm);
        Task<EmployeeCreatedForm> Delete(string id, string partition);
    }
}
