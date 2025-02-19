using System.Security.Cryptography.X509Certificates;

class QuizManager
{

    public List<Quiz> quizzes = new List<Quiz>();
    public void CreateQuiz()
    {
        Console.WriteLine("Ange namn på Quiz:");
        string? name = Console.ReadLine();

        Quiz quiz = new Quiz(name);
        quizzes.Add(quiz);

        while (true)
        {
            Console.WriteLine("Ange en fråga eller 'klar' för att avsluta");
            string? question = Console.ReadLine();

            if (question?.ToLower() == "klar") break;

            Console.WriteLine("Ange rätt svar: ");
            string? answer = Console.ReadLine();

            quiz.AddQuestion(question, answer);

            Console.WriteLine("Quiz " + name + " har skapats.");
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

        Console.WriteLine("Välj ett quiz (völj ett nummer): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= quizzes.Count){
            quizzes[choice - 1].Start();
        } else{
            Console.WriteLine("Försök igen.");
        }
    }
}
