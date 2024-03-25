namespace systemintegration_adresse_service.Models;

public class ValgDistrikt : CPRRecordHouseNumber
{
    public string VALGKOD { get; set; }
    public string DISTTXT { get; set; }

    public ValgDistrikt(string dataLine) : base(dataLine)
    {
        VALGKOD = SubStringTrim(dataLine, 34, 30);
        DISTTXT = SubStringTrim(dataLine, 32, 2);
        TIMESTAMP = SubStringTrim(dataLine, 20, 12);
    }
}
