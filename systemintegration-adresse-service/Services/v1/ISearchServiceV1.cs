using System.Text;
using System.Text.RegularExpressions;

namespace systemintegration_adresse_service.Services;

public interface ISearchServiceV1
{
    public String? FindByVejKodeAndKomKode(string vejkode, string komKode);

    public IList<String> FindStreetsFuzzySearch(string name);
}

public class SearchServiceV1 : ISearchServiceV1
{
    public String? FindByVejKodeAndKomKode(string vejkode, string komKode)
    {
        IEnumerable<String> addresseLinjer = File.ReadAllLines("C:\\A370715.txt", Encoding.Latin1);
        foreach (var line in addresseLinjer)
        {
            if (line.StartsWith("001"))
            {
                // guard for KomKode overshoot, KomKode are sorted, so early termination can be achieved
                if (CompareKomKode(komKode, line) > 0)
                {
                    break;
                }

                if (CompareKomKode(komKode, line) == 0 && CompareVejKode(vejkode, line) == 0)
                {
                    return line.Substring(71, 40).ToString();
                }
            }
        }

        return null;
    }

    public IList<string> FindStreetsFuzzySearch(string name)
    {
        IEnumerable<String> addresseLinjer = File.ReadAllLines("C:\\A370715.txt");
        IList<String> matches = new List<string>();
        foreach (var line in addresseLinjer)
        {
            if (!line.StartsWith("001")) continue;
            var streetName = line.Substring(71, 40);
            if (streetName.ToLower().StartsWith(name, StringComparison.CurrentCultureIgnoreCase))
            {
                matches.Add(streetName.Trim());
            }
        }
        return matches;
    }

    private static int CompareKomKode(string komKode, string line)
    {
        string _komKode = line.Substring(3, 4);
        return String.CompareOrdinal(_komKode, komKode);
    }

    private static int CompareVejKode(String vejkode, String line)
    {
        string _vejKode = line.Substring(7, 4);
        return String.CompareOrdinal(_vejKode, vejkode);
    }
}