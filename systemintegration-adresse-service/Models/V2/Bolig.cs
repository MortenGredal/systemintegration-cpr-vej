using System.Runtime.InteropServices.JavaScript;

namespace systemintegration_adresse_service.Models;

public class Bolig : CPRRecord
{
    public string HUSNR { get; set; }
    public string ETAGE { get; set; }
    public string SIDEDOER { get; set; }
    public string LOKALITET { get; set; }

    public Bolig(string dataLine) : base(dataLine)
    {
        HUSNR = SubStringTrim(dataLine, 11, 4);
        ETAGE = SubStringTrim(dataLine, 15, 2);
        SIDEDOER = SubStringTrim(dataLine, 17, 4);
        LOKALITET = SubStringTrim(dataLine, 58, 34);
        TIMESTAMP = SubStringTrim(dataLine, 21, 12);
    }
}
