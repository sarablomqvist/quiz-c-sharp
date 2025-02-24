
class QuizManager
{

    public List<Quiz> quizzes = new List<Quiz>();
    public void CreateQuiz()
    {
        Quiz quiz;

        using (var db = new QuizDbContext())
        {

            Console.WriteLine("Ange namn på Quiz:");
            string? name = Console.ReadLine();

            quiz = new Quiz { Name = name };
            db.Quizzes.Add(quiz);
            db.SaveChanges();
        }

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

            using (var db = new QuizDbContext())
            {
                var existingQuiz = db.Quizzes.FirstOrDefault(q => q.Name == quiz.Name);

                if (existingQuiz != null)
                {
                    Question newQuestion = new Question
                    {
                        Text = question,
                        Answer = answer,
                        Quiz = existingQuiz
                    };

                    db.Questions.Add(newQuestion);
                    db.SaveChanges();

                    Console.WriteLine($"Fråga '{question}' har lagts till i {quiz.Name}.");
                }
                else
                {
                    Console.WriteLine("Fel, kunde inte hitta i databasen.");
                };
            }
        }
    }

    public void PlayQuiz()
    {
        if (quizzes.Count == 0)
        {
            Console.WriteLine("Finns inga quiz än. Återgå och tryck på 1 för att skapa ett.");
            return;
        }

        Console.WriteLine("Tillgängliga quiz:");
        for (int i = 0; i < quizzes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizzes[i].Name}");
        }

        Console.WriteLine("Välj ett quiz (välj ett nummer): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= quizzes.Count)
        {
            quizzes[choice - 1].Start();
        }
        else
        {
            Console.WriteLine("Försök igen.");
        }
    }
}
