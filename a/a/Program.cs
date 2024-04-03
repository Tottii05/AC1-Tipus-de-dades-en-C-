using a;

namespace AC
{
    public class Program
    {
        //Creo un delegado que recibe una lista de scores y devuelve otra lista de scores ordenadas por puntuación de manera descendente
        public delegate List<Score> MyListOrderer(List<Score> x);
        public static List<Score> OrderByScoring(List<Score> uniqueScores)
        {
            uniqueScores.Sort((x, y) => x.Scoring.CompareTo(y.Scoring));
            uniqueScores.Reverse();
            return uniqueScores;
        }
        public static void Main()
        {
            const string PlayerInput = "Introduce el nombre del jugador";
            const string MissionInput = "Introduce el nombre de la misión";
            const string ScoringInput = "Introduce la puntuación";
            const string PlayerCreated = "Jugador número {0} creado\n";
            const string PlayersScores = "Jugador {0}, Misión {1}, Puntuación {2}";
            const string PlayerError = "El nombre del jugador no es válido\n";
            const string MissionError = "El nombre de la misión no es válido\n";
            const string ScoringError = "La puntuación no es válida\n";

            const int MaxScores = 10;
            bool playerOk, missionOk, scoringOk;
            List<Score> scores = new List<Score>();
            
            for (int i = 0; i < MaxScores; i++)
            {
                string player, mission;
                int scoring;
                do
                {
                    Console.WriteLine(PlayerInput);
                    player = Console.ReadLine();
                    playerOk = Helper.CheckPlayer(player);
                    if (!playerOk)
                    {
                        Console.WriteLine(PlayerError);
                    }
                }while(!playerOk);
                do
                {
                    Console.WriteLine(MissionInput);
                    mission = Console.ReadLine();
                    mission = Helper.ConvertToTitleCase(mission);
                    missionOk = Helper.CheckMission(mission);
                    if (!missionOk)
                    {
                        Console.WriteLine(MissionError);
                    }
                }while(!missionOk);
                do
                {
                    Console.WriteLine(ScoringInput);
                    scoring = Convert.ToInt32(Console.ReadLine());
                    scoringOk = Helper.CheckScoring(scoring);
                    if (!scoringOk)
                    {
                        Console.WriteLine(ScoringError);
                    }
                }while(!scoringOk);
                //Muestro por pantalla el jugador creado con el número de instacias que lleva creadas el bucle for
                Console.WriteLine(PlayerCreated, i + 1);
                //Además, añado la instacia creada a la lista de scores
                scores.Add(new Score(player, mission, scoring));
            }
            //Llamo a mi clase estática Helper y a su método GenerateUniqueRanking para obtener la lista de scores únicos por jugador y misión
            List<Score> uniqueScores = Helper.GenerateUniqueRanking(scores);
            //Llamo a mi delegado para que ordene la lista de scores únicos por puntuación
            MyListOrderer orderer = new MyListOrderer(OrderByScoring);
            List<Score> orderedScores = orderer(uniqueScores);
            foreach (var score in orderedScores)
            {
                Console.WriteLine(PlayersScores, score.Player, score.Mission, score.Scoring);
            }
        }
    }
}