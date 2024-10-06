public class ViaCepService
{
    private readonly HttpClient _httpClient;

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Endereco> GetAddressByCep(string cep)
    {
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        if (response.IsSuccessStatusCode)
        {
            var endereco = await response.Content.ReadFromJsonAsync<Endereco>();
            return endereco;
        }
        return null;
    }
}
