using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

class Question
{

    [Key]
    public int Id { get; set; }
    public string Text { get; set; }
    public string Answer { get; set; }

    [ForeignKey("Quiz")]
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }

    public Question() { }

    public Question(string text, string answer)
    {
        Text = text;
        Answer = answer;
    }

    public bool CheckAnswer(string response)
    {
        return response.Trim().Equals(Answer.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}
