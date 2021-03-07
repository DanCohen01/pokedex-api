using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace pokedex.Domain.InfrastructureModels
{
       
        public partial class PokemonSpecies
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("order")]
            public long Order { get; set; }

            [JsonProperty("gender_rate")]
            public long GenderRate { get; set; }

            [JsonProperty("capture_rate")]
            public long CaptureRate { get; set; }

            [JsonProperty("base_happiness")]
            public long BaseHappiness { get; set; }

            [JsonProperty("is_baby")]
            public bool IsBaby { get; set; }

            [JsonProperty("is_legendary")]
            public bool IsLegendary { get; set; }

            [JsonProperty("is_mythical")]
            public bool IsMythical { get; set; }

            [JsonProperty("hatch_counter")]
            public long HatchCounter { get; set; }

            [JsonProperty("has_gender_differences")]
            public bool HasGenderDifferences { get; set; }

            [JsonProperty("forms_switchable")]
            public bool FormsSwitchable { get; set; }

            [JsonProperty("growth_rate")]
            public Color GrowthRate { get; set; }

            [JsonProperty("pokedex_numbers")]
            public List<PokedexNumber> PokedexNumbers { get; set; }

            [JsonProperty("egg_groups")]
            public List<Color> EggGroups { get; set; }

            [JsonProperty("color")]
            public Color Color { get; set; }

            [JsonProperty("shape")]
            public Color Shape { get; set; }

            [JsonProperty("evolves_from_species")]
            public Color EvolvesFromSpecies { get; set; }

            [JsonProperty("evolution_chain")]
            public EvolutionChain EvolutionChain { get; set; }

            [JsonProperty("habitat")]
            public object Habitat { get; set; }

            [JsonProperty("generation")]
            public Color Generation { get; set; }

            [JsonProperty("names")]
            public List<Name> Names { get; set; }

            [JsonProperty("flavor_text_entries")]
            public List<FlavorTextEntry> FlavorTextEntries { get; set; }

            [JsonProperty("form_descriptions")]
            public List<FormDescription> FormDescriptions { get; set; }

            [JsonProperty("genera")]
            public List<Genus> Genera { get; set; }

            [JsonProperty("varieties")]
            public List<Variety> Varieties { get; set; }
        }

        public partial class Color
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }
        }

        public partial class EvolutionChain
        {
            [JsonProperty("url")]
            public Uri Url { get; set; }
        }

        public partial class FlavorTextEntry
        {
            [JsonProperty("flavor_text")]
            public string FlavorText { get; set; }

            [JsonProperty("language")]
            public Color Language { get; set; }

            [JsonProperty("version")]
            public Color Version { get; set; }
        }

        public partial class FormDescription
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("language")]
            public Color Language { get; set; }
        }

        public partial class Genus
        {
            [JsonProperty("genus")]
            public string GenusGenus { get; set; }

            [JsonProperty("language")]
            public Color Language { get; set; }
        }

        public partial class Name
        {
            [JsonProperty("name")]
            public string NameName { get; set; }

            [JsonProperty("language")]
            public Color Language { get; set; }
        }

        public partial class PokedexNumber
        {
            [JsonProperty("entry_number")]
            public long EntryNumber { get; set; }

            [JsonProperty("pokedex")]
            public Color Pokedex { get; set; }
        }

        public partial class Variety
        {
            [JsonProperty("is_default")]
            public bool IsDefault { get; set; }

            [JsonProperty("pokemon")]
            public Color Pokemon { get; set; }
        }
    }


