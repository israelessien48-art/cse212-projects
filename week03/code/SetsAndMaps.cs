using System.Text.Json;

public static class SetsAndMaps
{
    // =========================
    // Problem 1 – Find Pairs
    // =========================
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word.Length != 2) continue;
            if (word[0] == word[1]) continue; // skip "aa"

            string reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    // =========================
    // Problem 2 – Degree Summary
    // =========================
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    // =========================
    // Problem 3 – Anagrams
    // =========================
    public static bool IsAnagram(string word1, string word2)
    {
        var counts = new Dictionary<char, int>();

        foreach (char c in word1.ToLower())
        {
            if (c == ' ') continue;

            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2.ToLower())
        {
            if (c == ' ') continue;

            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;
            if (counts[c] == 0)
                counts.Remove(c);
        }

        return counts.Count == 0;
    }

    // =========================
    // Problem 5 – Earthquake JSON
    // =========================
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            results.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }

        return results.ToArray();
    }
}
