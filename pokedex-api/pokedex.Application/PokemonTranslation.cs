using pokedex.Application.Enums;
using pokedex.Application.Interfaces;
using pokedex.Application.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Application
{
    public class PokemonTranslation : IPokemonTranslation
    {
        ITranslationProvider _translationProvider;

        public PokemonTranslation(ITranslationProvider translationProvider)
        {
            
            _translationProvider = translationProvider;
        }
        public async Task<string> GetPokemonTranslation(string description, string habitat, bool isLegendary)
        {
            try
            {
                var translationType = TranslationType.original;
                switch (habitat, isLegendary)
                {
                    case (_, true):
                    case ("cave", _):
                        translationType = TranslationType.yoda;
                        break;
                    default:
                        translationType = TranslationType.shakespeare;
                        break;

                }

                if (translationType == TranslationType.original) return description;

                var translation = await _translationProvider.TranslateByTranslationType(description, translationType);
                if (string.IsNullOrWhiteSpace(translation))
                {
                    return description;
                }

               
                return translation;
            } catch(Exception e)
            {
                Log.Error(e, "Error translating pokemon description");
            }
            return description;
            
        }
    }
}
