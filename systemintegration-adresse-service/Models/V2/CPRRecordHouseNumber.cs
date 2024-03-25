using System.Text.Json.Serialization;

namespace systemintegration_adresse_service.Models;

public class CPRRecordHouseNumber(string dataLine) : CPRRecord(dataLine)
{
    public string HUSNRFRA { get; set; } = SubStringTrim(dataLine, 11, 4);
    public string HUSNRTIL { get; set; } = SubStringTrim(dataLine, 15, 4);
    public Lighed LIGEULIGE { get; set; } = SubStringTrim(dataLine, 19, 1)
        .Equals("L", StringComparison.CurrentCultureIgnoreCase) ? Lighed.LIGE : Lighed.ULIGE;
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Lighed
    {
        ULIGE,
        LIGE
    }
}