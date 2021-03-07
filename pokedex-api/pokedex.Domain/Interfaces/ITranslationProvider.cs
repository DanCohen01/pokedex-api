using pokedex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Domain.Interfaces
{
    public interface ITranslationProvider
    {
        Task<string> TranslateByTranslationType(string input, TranslationType translationType);
    }
}
