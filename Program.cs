class Program
{
    static void Main()
    {
        QuizManager manager = new QuizManager();

        Console.WriteLine("\n----QUIZ----\n");
        Console.WriteLine("1. Skapa quiz");
        Console.WriteLine("2. Spela quiz");
        Console.WriteLine("3. Avsluta\n");
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
                Console.WriteLine("Avslutar quiz");
            }
            else
            {
                Console.WriteLine("Välj en siffra mellan 1-3.");
            }
        }
    }
}
