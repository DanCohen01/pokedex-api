using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Domain.Configuration
{
    public class ExternalProviderSettings
    {
        public string PokemonApiUrl { get; set; }

        public string FunTranslationsUrl { get; set; }
    }
}
