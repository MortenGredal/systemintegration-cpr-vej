namespace systemintegration_adresse_service.Models;

public class AktVej : CPRRecord
{
    public string VEJKOD { get; set; }
    public string TILKOMKOD { get; set; }
    public string TILVEJKOD { get; set; }
    public string FRAKOMKOD { get; set; }
    public string FRAVEJKOD { get; set; }
    public string VEJADRNVN { get; set; }
    public string VEJNVN { get; set; }
    
    public List<Bolig> Boliger { get; set; } = [];
    public List<ByNavn> ByNavne { get; set; } = [];
    public List<KirkeDistrikt> KirkeDistrikter { get; set; } = [];
    public List<NotatVej> Notater { get; set; } = [];
    public List<PostDistrikt> PostDistriker { get; set; } = [];
    public List<SogneDistrikt> SogneDikstriker { get; set; } = [];
    public List<ValgDistrikt> ValgDistriker { get; set; } = [];

    public AktVej(string dataLine) : base(dataLine)
    {
        VEJKOD = SubStringTrim(dataLine, 7, 4);
        TILKOMKOD = SubStringTrim(dataLine, 23, 4);
        TILVEJKOD = SubStringTrim(dataLine, 27, 4);
        FRAKOMKOD = SubStringTrim(dataLine, 31, 4);
        FRAVEJKOD = SubStringTrim(dataLine, 35, 4);
        VEJADRNVN = SubStringTrim(dataLine, 51, 20);
        VEJNVN = SubStringTrim(dataLine, 71, 40);
        TIMESTAMP = SubStringTrim(dataLine,11, 12);
    }
}
