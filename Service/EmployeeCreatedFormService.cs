using Dynamic_Form_with_CosmosDb.Models;
using Microsoft.Azure.Cosmos;

namespace Dynamic_Form_with_CosmosDb.Service
{
    public class EmployeeCreatedFormService : IEmployeeCreatedFormService
    {
        private readonly Container _container;

        public EmployeeCreatedFormService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName,containerName);
        }
        public async Task<EmployeeCreatedForm> Add(EmployeeCreatedForm EmployeeCreatedForm)
        {
            var item = await _container.CreateItemAsync<EmployeeCreatedForm>(EmployeeCreatedForm, new PartitionKey(EmployeeCreatedForm.Id));

            return item;
        }
        public async Task<EmployeeCreatedForm> Delete(string id, string partition)
        {
            var result = await _container.DeleteItemAsync<EmployeeCreatedForm>(id, new PartitionKey(partition));
            return result;
        }
        public async Task<List<EmployeeCreatedForm>> Get(string cosmosQuery)
        {
            var query = _container.GetItemQueryIterator<EmployeeCreatedForm>(new QueryDefinition(cosmosQuery));
            List<EmployeeCreatedForm> results = new List<EmployeeCreatedForm>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<EmployeeCreatedForm> GetById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<EmployeeCreatedForm>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<EmployeeCreatedForm> Update(EmployeeCreatedForm employeeCreatedForm)
        {
            var item = await _container.UpsertItemAsync<EmployeeCreatedForm>(employeeCreatedForm, new PartitionKey(employeeCreatedForm.Id));
            return item;
        }
   }
}
