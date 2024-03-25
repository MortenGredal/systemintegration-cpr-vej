namespace systemintegration_adresse_service.Models;

public class KirkeDistrikt : CPRRecordHouseNumber
{
    public string KIRKEKOD { get; set; }
    public string DISTTXT { get; set; }

    public KirkeDistrikt(string dataLine) : base(dataLine)
    {
        KIRKEKOD = SubStringTrim(dataLine, 32, 2);
        DISTTXT = SubStringTrim(dataLine, 34, 30);
        TIMESTAMP = SubStringTrim(dataLine, 21, 12);
    }
}
