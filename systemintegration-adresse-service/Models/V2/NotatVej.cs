namespace systemintegration_adresse_service.Models;

public class NotatVej : CPRRecord
{
    
    public string NOTATNR { get; set; }
    public string NOTATLINIE { get; set; }

    public NotatVej(string dataLine) : base(dataLine)
    {
        NOTATNR = SubStringTrim(dataLine, 11, 2);
        NOTATLINIE = SubStringTrim(dataLine, 13, 40);
        TIMESTAMP = SubStringTrim(dataLine, 53, 12);
    }
}