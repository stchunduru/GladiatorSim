using System.Text.Json.Serialization;

namespace GladiatorSim.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GladiatorSponsor
    {
        Arenthius = 1,
        Macharius = 2,
        Flavianus = 3,
        Bruttius = 4,
        Quintillus = 5
    }
}
