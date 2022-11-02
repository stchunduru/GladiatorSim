using System.Text.Json.Serialization;

namespace GladiatorSim.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GladiatorHistory
    {
        Laborer = 1,
        Farmer = 2,
        Noble = 3,
        Vigiles = 4,
        Legionnarie = 5,
        Thief,
        Murderer,
        Convict = 6,
        Debtor = 7
    }
}
