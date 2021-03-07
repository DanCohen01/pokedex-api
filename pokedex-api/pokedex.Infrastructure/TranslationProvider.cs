using Microsoft.Extensions.Options;
using pokedex.Domain.Configuration;
using pokedex.Domain.Enums;
using pokedex.Domain.InfrastructureModels;
using pokedex.Domain.Interfaces;
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
            _translationApiUrl = externalProviderSettings.Value.FunTranslationsUrl;
        }
        public async Task<string> TranslateByTranslationType(string input, TranslationType translationType)
        {

            try
            {

                var client = _httpClientFactory.CreateClient(_translationApiUrl);
                var data = new StringContent(input, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(translationType.ToString(),data);
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var translation = await JsonSerializer.DeserializeAsync<Translation>(responseStream);
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
