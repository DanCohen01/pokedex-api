using pokedex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Domain.Interfaces
{
    public interface ITranslator
    {
        string Translate(string input, TranslationType translationType);
    }
}
