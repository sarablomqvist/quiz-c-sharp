class Program
{
    static void Main()
    {
        QuizManager manager = new QuizManager();

        while (true)
        {
            Console.WriteLine("----QUIZ----");
            Console.WriteLine("1. Skapa quiz");
            Console.WriteLine("2. Spela quiz");
            Console.WriteLine("3. Avsluta");
            Console.WriteLine("Välj ett alternativ:");

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
                Console.WriteLine("Avslutar quiz");
            }
            else
            {
                Console.WriteLine("Välj en siffra mellan 1-3.");
            }
        }
    }
}
