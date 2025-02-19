class Quiz
{
    public string Name { get; set; }
    public List<Question> Questions { get; set; }

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
        Console.WriteLine($"Quiz klart! Du fick  + {score}/{Questions.Count} + poäng.");
    }
}
