using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public class PlianceClient : IPlianceClient
    {
        private readonly PlianceClientFactory _factory;
        private readonly string _givenName;
        private readonly string _subject;

        public PlianceClient(PlianceClientFactory factory, string givenName, string subject)
        {
            _subject = subject;
            _givenName = givenName;
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<RegisterPersonResponse> RegisterPerson(RegisterPersonCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await Execute(async (client) =>
            {
                var response = await client.PutAsync("api/PersonCommand", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RegisterPersonResponse>(responseString);

                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return result;
            });
        }

        public async Task<ArchivePersonResponse> ArchivePerson(ArchivePersonCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await Execute(async (client) =>
            {
                var response = await client.PostAsync("api/PersonCommand/Archive", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ArchivePersonResponse>(responseString);

                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return result;
            });
        }

        public async Task<DeletePersonResponse> DeletePerson(DeletePersonCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await Execute(async (client) =>
            {
                var response = await client.PostAsync("api/PersonCommand", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<DeletePersonResponse>(responseString);

                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return result;
            });
        }

        public async Task<ClassifyHitResponse> ClassifyPersonHit(ClassifyHitCommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await Execute(async (client) =>
            {
                var response = await client.PostAsync("api/PersonCommand/Classify", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ClassifyHitResponse>(responseString);

                if (!result.Success)
                {
                    throw new Exception(result.Message);
                }

                return result;
            });
        }

        public async Task Ping()
        {
            await Execute<object>(async (client) =>
            {
                var response = await client.GetAsync("api/Ping");

                var responseString = await response.Content.ReadAsStringAsync();
                return null;
            });
        }

        private Task<T> Execute<T>(Func<HttpClient, Task<T>> action)
        {
            return _factory.Execute<T>(action, _givenName, _subject);
        }
    }
}
