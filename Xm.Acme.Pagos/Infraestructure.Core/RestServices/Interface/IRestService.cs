using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Core.RestServices.Interface
{
    public interface IRestService
    {
        Task<T> GetRestServiceAsync<T>(string url, string method, IDictionary<string,
           string> parameters, IDictionary<string, string> headeres);

        Task<T> PostRestServiceAsync<T>(string url, string controller,
            string method, object parameters, IDictionary<string, string> headers);
    }
}
