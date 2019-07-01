using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pliance.SDK.Contract;

namespace Pliance.SDK
{
    public class PlianceClient
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

            var client = _factory.Create(_givenName, _subject);
            var json = JsonConvert.SerializeObject(command);
            var content = new StringContent(json, Encoding.UTF8, "application/json"); ;
            var response = await client.PutAsync("api/PersonCommand", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RegisterPersonResponse>(responseString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result;
        }

        public async Task Ping()
        {
            var client = _factory.Create("", "");
            var response = await client.GetAsync("api/Ping");
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RegisterPersonResponse>(responseString);

            Console.WriteLine(responseString);
        }
    }
}
