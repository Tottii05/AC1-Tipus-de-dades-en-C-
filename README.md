# Bibliografía consultada
- Regular expression101 (2024/04/03) (https://regex101.com/)
- Viquipèdia (2024/04/03) (https://ca.wikipedia.org/wiki/Alfabet_grec)

# IA consultada
- Github Copilot
- - Resultado 1:

```
return (from score in scores
        where uniqueScores.Contains(score.Scoring)
        select score).ToList();
```
    
- - Resultado 2:
```
uniqueScores.Sort((x, y) => x.Scoring.CompareTo(y.Scoring));
```

- ChatGPT
- - resultado 1:
```
public static List<Score> OrderByScoring(List<Score> scores)
{
    scores.Sort((x, y) => x.Scoring.CompareTo(y.Scoring));
    return scores;
}
```
