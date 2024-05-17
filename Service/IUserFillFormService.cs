using Dynamic_Form_with_CosmosDb.Models;

namespace Dynamic_Form_with_CosmosDb.Service
{
    public interface IUserFillFormService
    {
        Task<List<UserFillForm>> Get(string query);
        Task<UserFillForm> GetById(string id);
        Task<UserFillForm> Add(UserFillForm userFillForm);
        Task<UserFillForm> Update(UserFillForm userFillForm);
        Task<UserFillForm> Delete(string id, string partition);
    }
}
