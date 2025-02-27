class Program
{
    static void Main()
    {
        QuizManager manager = new QuizManager();

        Console.WriteLine("\n----QUIZ----\n");
        Console.WriteLine("1. Skapa quiz");
        Console.WriteLine("2. Spela quiz");
        Console.WriteLine("3. Hämta quiz från databasen");
        Console.WriteLine("4. Visa highscore");
        Console.WriteLine("5. Avsluta\n");
        Console.WriteLine("Välj ett alternativ:");

        while (true)
        {

            string? choice = Console.ReadLine();

            if (choice == "1")
            {
                manager.CreateQuiz();
            }
            else if (choice == "2")
            {
                manager.PlayQuiz();
            }
            else if (choice == "3")
            {
                manager.GetQuizFromDatabase();
            }
            else if (choice == "4")
           {
                manager.ShowHighscores();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Avslutar quiz");
                break;
            }
            else
            {
                Console.WriteLine("Välj en siffra mellan 1-4.");
            }
        }
    }
}
