using Microsoft.Extensions.Options;
using pokedex.Application.Configuration;
using pokedex.Application.Enums;
using pokedex.Application.InfrastructureModels;
using pokedex.Application.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pokedex.Infrastructure
{
    public class TranslationProvider : ITranslationProvider
    {
        private IHttpClientFactory _httpClientFactory;
        private string _translationApiUrl;

        public TranslationProvider(IHttpClientFactory clientFactory, IOptions<ExternalProviderSettings> externalProviderSettings)
        {
            _httpClientFactory = clientFactory;
            _translationApiUrl = externalProviderSettings.Value.FunTranslationsApiUrl;
        }
        public async Task<string> TranslateByTranslationType(string input, TranslationType translationType)
        {

            try
            {
                var requestUri = $"{_translationApiUrl}/{translationType}?text={input}";
                var client = _httpClientFactory.CreateClient();
             
                var response = await client.GetAsync(requestUri);
                var cont = await response.Content.ReadAsStringAsync();
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var translation = await JsonSerializer.DeserializeAsync<Translation>(responseStream);
                    if (string.IsNullOrWhiteSpace(translation?.Contents?.Translated)) return input;
                    return translation?.Contents?.Translated;
                }

            }
            catch (Exception e)
            {
                Log.Error(e, $"Error calling translation api");
                throw;

            }
        }
    }
}
