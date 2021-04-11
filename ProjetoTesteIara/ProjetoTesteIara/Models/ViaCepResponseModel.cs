using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetoTesteIara.Models
{
    public class ViaCepResponseModel
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Uf { get; set; }

        public async Task<ViaCepResponseModel> ViaCepResponse(string CEP)
        {
            try
            {
                HttpClient client = new HttpClient();

                var endereco = await client.GetStringAsync($"https://viacep.com.br/ws/{CEP}/json/");

                var response = new ViaCepResponseModel();

                var opt = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                response = JsonSerializer.Deserialize<ViaCepResponseModel>(endereco, opt);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
