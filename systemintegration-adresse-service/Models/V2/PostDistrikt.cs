namespace systemintegration_adresse_service.Models;

public class PostDistrikt : CPRRecordHouseNumber
{
    public string POSTNR { get; set; }
    public string POSTDISTTXT { get; set; }

    public PostDistrikt(string dataLine) : base(dataLine)
    {
        POSTNR = SubStringTrim(dataLine, 32, 4);
        POSTDISTTXT = SubStringTrim(dataLine, 36, 20);
        TIMESTAMP = SubStringTrim(dataLine, 21, 12);
    }
}
