using System.Text.Json;
using PontosTuristicos.Models.IBGE;

namespace PontosTuristicos.Services
{
    public class IbgeService
    {
        private readonly HttpClient _http;

        public IbgeService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<EstadoIbge>> BuscarEstados()
        {
            var response = await _http.GetStringAsync(
                "https://servicodados.ibge.gov.br/api/v1/localidades/estados"
            );


            var estados = JsonSerializer.Deserialize<List<EstadoIbge>>(response);


            return estados?
                .OrderBy(x => x.Nome)
                .ToList()
                ?? new List<EstadoIbge>();
        }



        public async Task<List<CidadeIbge>> BuscarCidades(string estado)
        {
            var response = await _http.GetStringAsync(
                $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{estado}/municipios"
            );


            var cidades = JsonSerializer.Deserialize<List<CidadeIbge>>(response);


            return cidades?
                .OrderBy(x => x.Nome)
                .ToList()
                ?? new List<CidadeIbge>();
        }
    }
}