namespace systemintegration_adresse_service.Models;

public class CPRRecord(string dataLine)
{
    public string KOMKOD { get; set; } = SubStringTrim(dataLine, 3, 4);
    public string VEJKOD { get; set; } = SubStringTrim(dataLine, 7, 4);
    public string TIMESTAMP { get; set; } = SubStringTrim(dataLine, 20, 12);

    protected static string SubStringTrim(string dateLine, int startIndex, int length)
    {
        return dateLine.Substring(startIndex, length).Trim();
    }
    
}