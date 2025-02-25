using System.ComponentModel.DataAnnotations;
using System.Data;

class Quiz
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Question> Questions { get; set; }

    public Quiz() { }

    public Quiz(string name)
    {
        Name = name;
        Questions = new List<Question>();
    }

    public void AddQuestion(string text, string answer)
    {
        Questions.Add(new Question(text, answer));
    }

    public void Start()
    {
        Console.WriteLine("Startar quiz: " + Name);
        int score = 0;

        foreach (var q in Questions)
        {
            Console.WriteLine(q.Text + " ");
            string? response = Console.ReadLine();

            if (q.CheckAnswer(response))
            {
                Console.WriteLine("Rätt!");
                score++;
            }
            else
            {
                Console.WriteLine($"Fel.. Rätt svar är {q.Answer}");
            }
        }
        Console.WriteLine($"Quiz klart! Du fick {score}/{Questions.Count} poäng.");
        SaveHighscore(score, this.Id);
        ShowHighscores();
    }

    public void SaveHighscore(int score, int quizId)
    {
        using (var db = new QuizDbContext())
        {
            var highscore = new Highscore
            {
                Score = score,
                QuizId = quizId
            };

            db.Highscores.Add(highscore);
            db.SaveChanges();

            Console.WriteLine($"Ditt resultat: {score} poäng har sparats i highscore!");
        }
    }

    public void ShowHighscores()
    {
        using (var db = new QuizDbContext())
        {
            var highscores = db.Highscores
            .Where(h => h.QuizId == this.Id)
            .OrderByDescending(h => h.Score)
            .Take(10)
            .ToList();

            if (highscores.Any())
            {
                Console.WriteLine("---Topplista för highscore!---");
                foreach (var highscore in highscores)
                {
                    Console.WriteLine($"Poäng: {highscore.Score}");
                }
            }
            else
            {
                Console.WriteLine("Inga highscore finns än.");
            }
        }
    }


}
