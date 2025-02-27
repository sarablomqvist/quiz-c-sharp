
using Microsoft.EntityFrameworkCore;

class QuizManager
{
    public QuizManager()
    {
        using (var db = new QuizDbContext())
        {
            db.Database.EnsureCreated();
        }
    }

    public List<Quiz> quizzes = new List<Quiz>();

    public void CreateQuiz()
    {
        using (var db = new QuizDbContext())
        {

            Console.WriteLine("Ange namn på Quiz:");
            string? name = Console.ReadLine();
            var quiz = new Quiz { Name = name };

            db.Quizzes.Add(quiz);
            db.SaveChanges();

            while (true)
            {
                Console.WriteLine("Ange en fråga eller 'klar' för att avsluta");
                string? question = Console.ReadLine();

                if (question?.ToLower() == "klar")
                {
                    Console.WriteLine("\n1. Skapa ett nytt quiz");
                    Console.WriteLine("2. Spela quiz");
                    Console.WriteLine("3. Avsluta");
                    Console.WriteLine("Välj ett alternativ:\n");
                    break;
                }

                Console.WriteLine("Ange rätt svar: ");
                string? answer = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(question) && !string.IsNullOrWhiteSpace(answer))
                {
                    Question newQuestion = new Question
                    {
                        Text = question,
                        Answer = answer,
                        QuizId = quiz.Id
                    };

                    db.Questions.Add(newQuestion);
                    db.SaveChanges();

                    Console.WriteLine($"Fråga '{question}' har lagts till i {quiz.Name}.");
                }
                else
                {
                    Console.WriteLine("Fråga och svar får inte vara tomma.");
                }
            }
        }
    }


    public void PlayQuiz()
    {
        using (var db = new QuizDbContext())
        {
            var quizzesFromDb = db.Quizzes.Include(q => q.Questions).ToList();

            if (quizzesFromDb.Count == 0)
            {
                Console.WriteLine("Finns inga quiz än. Återgå och tryck på 1 för att skapa ett.");
                return;
            }

            Console.WriteLine("Tillgängliga quiz:");
            for (int i = 0; i < quizzesFromDb.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quizzesFromDb[i].Name}");
            }

            Console.WriteLine("Välj ett quiz (välj ett nummer): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= quizzesFromDb.Count)
            {
                quizzesFromDb[choice - 1].Start();
            }
            else
            {
                Console.WriteLine("Försök igen.");
            }
        }
    }

    public void GetQuizFromDatabase()
    {
        using (var db = new QuizDbContext())
        {
            Console.WriteLine("Hämtar quiz från databasen..");
            var quizzesFromDb = db.Quizzes.Include(q => q.Questions).ToList();

            if (quizzesFromDb.Any())
            {
                foreach (var q in quizzesFromDb)
                {
                    Console.WriteLine($"Quiz: {q.Name}");
                    Console.WriteLine("Frågor:");

                    foreach (var question in q.Questions)
                    {
                        Console.WriteLine($"- {question.Text} (Rätt svar: {question.Answer})");
                    }
                }
            }
            else
            {
                Console.WriteLine("Inga quiz hittades.");
            }
        }
    }

    public void ShowHighscoresForQuiz(int quizId)
    {
        using (var db = new QuizDbContext())
        {
            Console.WriteLine($"Hämtar highscore för QuizId: {quizId}");

            var highscores = db.Highscores
                .Where(h => h.QuizId == quizId)
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

    public void ShowHighscores()
    {
        using (var db = new QuizDbContext())
        {
            var quizzes = db.Quizzes.ToList();
            if (!quizzes.Any())
            {
                Console.WriteLine("Inga quiz finns i databasen.");
                return;
            }

            Console.WriteLine("Välj ett quiz att visa highscore för:");
            for (int i = 0; i < quizzes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quizzes[i].Name}");
            }

            if (int.TryParse(Console.ReadLine(), out int quizChoice) && quizChoice > 0 && quizChoice <= quizzes.Count)
            {
                int quizId = quizzes[quizChoice - 1].Id;
                ShowHighscoresForQuiz(quizId);
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
            }
        }
    }
}
