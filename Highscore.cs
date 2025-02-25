using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

class Highscore
{
    [Key]
    public int Id { get; set; }

    public int Score { get; set; }

    [ForeignKey("Quiz")]
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }

}
