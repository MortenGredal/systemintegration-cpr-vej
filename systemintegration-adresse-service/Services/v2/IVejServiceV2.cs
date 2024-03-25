using System.Text;
using systemintegration_adresse_service.Models;

namespace systemintegration_adresse_service.Services;

public interface IVejServiceV2
{
    public AktVej? FindByKomKodeVejKode(string komkode, string vejkode);

    public IEnumerable<AktVej> FindVejByNameFuzzySearch(string name);
}

public class VejServiceV2 : IVejServiceV2
{
    public AktVej? FindByKomKodeVejKode(string komkode, string vejkode)
    {
        var veje = ReadVeje();
        
        // TODO, this could probably be done using LINQ, but early termination is important to avoid iterating through an entire list if none is found on KOMKODE
        foreach (var vej in veje)
        {
            // guard for KomKode overshoot, KomKode are sorted, so early termination can be achieved
            if (string.CompareOrdinal(komkode, vej.KOMKOD) > 0)
            {
                break;
            }

            if (string.CompareOrdinal(vej.VEJKOD, vejkode) == 0 && 
                string.CompareOrdinal(vejkode, vej.VEJKOD) == 0)
            {
                return vej;
            }

        }
        
        return veje.First(vej => vej.VEJKOD.Equals(vejkode) && vej.KOMKOD.Equals(komkode));
    }

    public IEnumerable<AktVej> FindVejByNameFuzzySearch(string name)
    {
        return ReadVeje()
            .Where(v => v.VEJNVN.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }

    public ICollection<AktVej> ReadVeje()
    {
        IEnumerable<String> addresseLinjer = File.ReadAllLines("C:\\A370715.txt");

        var veje = new List<AktVej>();
        AktVej? aktVej = null;
        bool hasReachedEndRecord = false;

        foreach (var adr in addresseLinjer)
        {
            var type = adr.Substring(0, 3);

            // Data in text file is stored in a pseudo 2 layer-tree-like format
            // 001 acting as the root.
            // 001071000512006122212000000000000000000190001010000Banealle            Banealle            ---- root                    
            // 00407100051002A006FL2018092921108881Thors               
            // 00407100051001A003 U2018092921108881Thors               
            // 00907100051002A006FL20220808094627Thors                         
            // 00907100051001A003 U20220808094627Thors                         
            // 01307100051002A006FL2022080809468491Thors ,Favrskov     
            // 01307100051001A003 U2022080809468491Thors ,Favrskov     
            // 01407100051002A006FL20220808094610Thors /Haurum/Sall            
            // 01407100051001A003 U20220808094610Thors /Haurum/Sall            
            // 001071000532006122212000000000000000000190001010000Banealle            Banealle            ---- root                    
            // 00407100053006A008LL2018092921108450Hammel     ....
            // etc etc etc
            // 

            switch (type)
            {
                case "000":
                    // start record, ignore
                    break;
                case "001":
                    aktVej = new AktVej(adr);
                    veje.Add(aktVej);
                    break;
                case "002":
                    aktVej?.Boliger.Add(new Bolig(adr));
                    break;
                case "003":
                    aktVej?.ByNavne.Add(new ByNavn(adr));
                    break;
                case "004":
                    aktVej?.PostDistriker.Add(new PostDistrikt(adr));
                    break;
                case "005":
                    aktVej?.Notater.Add(new NotatVej(adr));
                    break;
                case "006":
                    // deprecated data BYFORNYDIST
                    break;
                case "007":
                    // deprecated data DIVDIST
                    break;
                case "008":
                    // deprecated data EVAKUERDIST
                    break;
                case "009":
                    aktVej?.KirkeDistrikter.Add(new KirkeDistrikt(adr));
                    break;
                case "010":
                    // deprecated data SKOLEDIST
                case "011":
                    // deprecated data BEFOLKDIST
                case "012":
                    // deprecated data SOCIALDIST
                case "013":
                    aktVej?.SogneDikstriker.Add(new SogneDistrikt(adr));
                    break;
                case "014":
                    aktVej?.ValgDistriker.Add(new ValgDistrikt(adr));
                    break;
                case "015":
                    // deprecated data VARMEDIST
                    break;
                default:
                    Console.WriteLine($"Wait a minute, I'm not supposed to be here! {type}");
                    break;
            }
        }

        return veje;
    }
    
}