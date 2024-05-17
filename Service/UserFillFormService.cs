using Dynamic_Form_with_CosmosDb.Models;
using Microsoft.Azure.Cosmos;

namespace Dynamic_Form_with_CosmosDb.Service
{
    public class UserFillFormService : IUserFillFormService
    {
        private readonly Container _container;

        public UserFillFormService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }
        public async Task<UserFillForm> Add(UserFillForm userFillForm)
        {
            var item = await _container.CreateItemAsync<UserFillForm>(userFillForm, new PartitionKey(userFillForm.Id));

            return item;
        }
        public async Task<UserFillForm> Delete(string id, string partition)
        {
            var result = await _container.DeleteItemAsync<UserFillForm>(id, new PartitionKey(partition));
            return result;
        }
        public async Task<List<UserFillForm>> Get(string cosmosQuery)
        {
            var query = _container.GetItemQueryIterator<UserFillForm>(new QueryDefinition(cosmosQuery));
            List<UserFillForm> results = new List<UserFillForm>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<UserFillForm> GetById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<UserFillForm>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<UserFillForm> Update(UserFillForm userFillForm)
        {
            var item = await _container.UpsertItemAsync<UserFillForm>(userFillForm, new PartitionKey(userFillForm.Id));
            return item;
        }
    }
}
