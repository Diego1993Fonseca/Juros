using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Juros.Domain.Intefaces.Business.Extern;
using Juros.Domain.Model;
using Juros.Domain.Model.DTO;
using Newtonsoft.Json;

namespace Juros.Business.Services.Extern
{
    public class TaxaJurosService : ITaxaJurosService
    {
        readonly Config _apiConfig;

        public TaxaJurosService(Config apiConfig) 
        {
            _apiConfig = apiConfig;
        }

        public async ValueTask<JurosDTO> getTaxaJuros()
        {
            try
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(_apiConfig.ApiUrl)
                };

                var request = new HttpRequestMessage(HttpMethod.Get, $"juros/taxaJuros");
               
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var juros = JsonConvert.DeserializeObject<JurosDTO>(json);

                    return juros;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Não foi possível obter a taxa de juros, erro: {ex.Message}");

            }
            
        }
    }
}
