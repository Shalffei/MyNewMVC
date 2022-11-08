using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Net;
using RestSharp;
using MyNewMVC.Models;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using Method = RestSharp.Method;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyNewMVC.Service
{
    public class GetRequestToApi
    {
        // базовые настройки сериализатора textJson, пишу сюда ибо настройки много места занимают
        public static readonly JsonSerializerOptions BaseTextJsonSerializerWriteSettings = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public static readonly JsonSerializerOptions BaseTextJsonSerializerReadSettings = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
        };
        public ModelProductForView GetProducts(int page)
        {
            var client = new RestClient("https://localhost:7024");
            var request = new RestRequest($"Product/GetRozetcaProducts?page={page}", Method.Get);
            var response = client.Get(request);
            return JsonSerializer.Deserialize<ModelProductForView>(response.Content, BaseTextJsonSerializerReadSettings);
        }
        public Product GetProductById(int id)
        {
            var client = new RestClient("https://localhost:7024");
            var request = new RestRequest($"Product/GetProductById?id={id}", Method.Get);
            var response = client.Get(request);
            return JsonSerializer.Deserialize<Product>(response.Content, BaseTextJsonSerializerReadSettings);
        }
    }
}
