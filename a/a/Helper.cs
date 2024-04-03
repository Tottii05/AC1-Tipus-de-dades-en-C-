using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace a
{
    public static class Helper
    {
        public static bool CheckPlayer(string player)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return regex.IsMatch(player);
        }
        public static string ConvertToTitleCase(string input)
        {
            string[] words = input.Split('-');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
            }
            return string.Join("-", words);
        }
        public static bool CheckMission(string mission)
        {
            Regex pattern = new Regex(@"^(Alfa|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mi|Ni|Ksi|Omicron|Pi|Ro|Sigma|Tau|Ipsilon|Fi|Khi|Psi|Omega)-\d{3}");
            return pattern.IsMatch(mission);
        }
        public static bool CheckScoring(int scoring)
        {
            return scoring >= 0 && scoring <= 500;
        }
        public static List<Score> GenerateUniqueRanking(List<Score> scores)
        {
            var uniqueScores = from score in scores
                               group score by new { score.Player, score.Mission } into unique
                               select unique.Max(score => score.Scoring);


            return (from score in scores
                    where uniqueScores.Contains(score.Scoring)
                    select score).ToList();
        }
    }
}
