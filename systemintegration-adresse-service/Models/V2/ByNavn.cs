namespace systemintegration_adresse_service.Models;

public class ByNavn : CPRRecordHouseNumber
{
    public string BYNVN { get; set; }

    public ByNavn(string dataLine) : base(dataLine)
    {
        BYNVN = SubStringTrim(dataLine, 32, 34);
        TIMESTAMP = SubStringTrim(dataLine, 21, 12);
    }
}
