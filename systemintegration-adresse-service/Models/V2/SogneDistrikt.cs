namespace systemintegration_adresse_service.Models;

public class SogneDistrikt : CPRRecordHouseNumber
{
    public string MYNKOD { get; set; }
    public string MYNNVN { get; set; }

    public SogneDistrikt(string dataLine) : base(dataLine)
    {
        MYNKOD = SubStringTrim(dataLine, 32, 4);
        MYNNVN = SubStringTrim(dataLine, 36, 20);
        TIMESTAMP = SubStringTrim(dataLine, 21, 12);
    }
}
