class Question
{
    public string Text { get; set; }
    public string Answer { get; set; }

    public Question(string text, string answer)
    {
        Text = text;
        Answer = answer;
    }

    public bool CheckAnswer(string input)
    {
        return input.Trim().Equals(Answer, StringComparison.OrdinalIgnoreCase);
    }
}
