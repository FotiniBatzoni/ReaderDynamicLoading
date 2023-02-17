using PersonReader.Interface;
using System.Net;
using System.Text.Json;

namespace PersonReader.Service
{
    public class ServiceReader : IPersonReader
    {
        WebClient client = new WebClient();
        string baseUri = "https://localhost:7258";
        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public IEnumerable<Person> GetPeople()
        {
           string address = $"{baseUri}/people";
           string reply = client.DownloadString(address);
           return JsonSerializer.Deserialize<IEnumerable<Person>>(reply, options);
        }

        public Person GetPerson(int id)
        {
            string address = $"{baseUri}/people/{id}";
            string reply = client.DownloadString(address);
            return JsonSerializer.Deserialize<Person>(reply);
        }
    }
}