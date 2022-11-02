using System.Text.Json.Serialization;

namespace GladiatorSim.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GladiatorOrigin
    {
        Gallia = 1,
        Hispania = 2,
        Italia = 3,
        Thracia = 4,
        Syria = 5,
        Aegyptus = 6,
        Germania = 7,
        Dacia = 8,
        Dalmatia = 9
    }
}
