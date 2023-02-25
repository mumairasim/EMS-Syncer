using Newtonsoft.Json;
using Syncer.Data.Entities;
using Syncer.Data.Enums;
using Syncer.Data.Interface;
using Syncer.Service.Models;
using Syncer.Service.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Syncer.Service.Services.Implementation
{
    public class PushService : IPushService
    {

        private readonly IRepository _repository;

        public PushService(IRepository repository)
        {
            _repository = repository;
        }

        public void PushPending<T>(string url) where T : DomainBaseEnitity
        {
            var pendingList = _repository.GetQuery<T>().Where(x => x.ApprovalStatus == RequestStatus.Pending && x.IsDeleted == false).ToList();
            SendList(pendingList, url);

        }
        private void SendList<T>(List<T> list, string url) where T : DomainBaseEnitity
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(list);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                // Make an HTTP GET request to the specified URL
                var responseTask = httpClient.PostAsync(url, content);

                // Wait for the response to complete and read the response content as a string
                var responseContentTask = responseTask.Result.Content.ReadAsStringAsync();
                var responseContent = responseContentTask.Result;
                var finalResponse = JsonConvert.DeserializeObject<GenericApiResponse>(responseContent);
                if (finalResponse != null && finalResponse.StatusCode.Equals("200", System.StringComparison.CurrentCultureIgnoreCase))
                    UpdateDatabase<T>();
            }
        }
        private void UpdateDatabase<T>() where T : DomainBaseEnitity
        {
            _repository.GetQuery<T>().Where(x => x.ApprovalStatus == RequestStatus.Pending && x.IsDeleted == false).ToList().ForEach(x => x.IsSent = true);
            _repository.SaveChanges();
        }
    }
}
