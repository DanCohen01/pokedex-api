using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace pokedex.Application.InfrastructureModels
{
       
        public  class PokemonSpecies
        {
            [JsonPropertyName("id")]
            public long Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("order")]
            public long Order { get; set; }

            [JsonPropertyName("gender_rate")]
            public long GenderRate { get; set; }

            [JsonPropertyName("capture_rate")]
            public long CaptureRate { get; set; }

            [JsonPropertyName("base_happiness")]
            public long BaseHappiness { get; set; }

            [JsonPropertyName("is_baby")]
            public bool IsBaby { get; set; }

            [JsonPropertyName("is_legendary")]
            public bool IsLegendary { get; set; }

            [JsonPropertyName("is_mythical")]
            public bool IsMythical { get; set; }

            [JsonPropertyName("hatch_counter")]
            public long HatchCounter { get; set; }

            [JsonPropertyName("has_gender_differences")]
            public bool HasGenderDifferences { get; set; }

            [JsonPropertyName("forms_switchable")]
            public bool FormsSwitchable { get; set; }

            [JsonPropertyName("growth_rate")]
            public Item GrowthRate { get; set; }

            [JsonPropertyName("pokedex_numbers")]
            public List<PokedexNumber> PokedexNumbers { get; set; }

            [JsonPropertyName("egg_groups")]
            public List<Item> EggGroups { get; set; }

            [JsonPropertyName("Item")]
            public Item Item { get; set; }

            [JsonPropertyName("shape")]
            public Item Shape { get; set; }

            [JsonPropertyName("evolves_from_species")]
            public Item EvolvesFromSpecies { get; set; }

            [JsonPropertyName("evolution_chain")]
            public EvolutionChain EvolutionChain { get; set; }

            [JsonPropertyName("habitat")]
            public Item Habitat { get; set; }

            [JsonPropertyName("generation")]
            public Item Generation { get; set; }

            [JsonPropertyName("names")]
            public List<Name> Names { get; set; }

            [JsonPropertyName("flavor_text_entries")]
            public List<FlavorTextEntry> FlavorTextEntries { get; set; }

            [JsonPropertyName("form_descriptions")]
            public List<FormDescription> FormDescriptions { get; set; }

            [JsonPropertyName("genera")]
            public List<Genus> Genera { get; set; }

            [JsonPropertyName("varieties")]
            public List<Variety> Varieties { get; set; }
        }

        public partial class Item
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("url")]
            public Uri Url { get; set; }
        }

    


    public partial class EvolutionChain
        {
            [JsonPropertyName("url")]
            public Uri Url { get; set; }
        }

        public partial class FlavorTextEntry
        {
            [JsonPropertyName("flavor_text")]
            public string FlavorText { get; set; }

            [JsonPropertyName("language")]
            public Item Language { get; set; }

            [JsonPropertyName("version")]
            public Item Version { get; set; }
        }

        public partial class FormDescription
        {
            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("language")]
            public Item Language { get; set; }
        }

        public partial class Genus
        {
            [JsonPropertyName("genus")]
            public string GenusGenus { get; set; }

            [JsonPropertyName("language")]
            public Item Language { get; set; }
        }

        public partial class Name
        {
            [JsonPropertyName("name")]
            public string NameName { get; set; }

            [JsonPropertyName("language")]
            public Item Language { get; set; }
        }

        public partial class PokedexNumber
        {
            [JsonPropertyName("entry_number")]
            public long EntryNumber { get; set; }

            [JsonPropertyName("pokedex")]
            public Item Pokedex { get; set; }
        }

        public partial class Variety
        {
            [JsonPropertyName("is_default")]
            public bool IsDefault { get; set; }

            [JsonPropertyName("pokemon")]
            public Item Pokemon { get; set; }
        }
    }


