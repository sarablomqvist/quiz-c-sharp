using System.ComponentModel.DataAnnotations;

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
        QuizManager manager = new QuizManager();
        manager.ShowHighscoresForQuiz(this.Id);

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
        SaveHighscore(score);
    }

    public void SaveHighscore(int score)
    {
        using (var db = new QuizDbContext())
        {
            if (this.Id == 0)
            {
                Console.WriteLine("Fel: Highscore kan inte sparas korrekt.");
                return;
            }

            var highscore = new Highscore
            {
                Score = score,
                QuizId = this.Id
            };

            db.Highscores.Add(highscore);
            db.SaveChanges();

            Console.WriteLine($"Ditt resultat: {score} poäng har sparats i highscore!");
        }
    }
}
