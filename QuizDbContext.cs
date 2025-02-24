using Microsoft.EntityFrameworkCore;

class QuizDbContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Highscore> Highscores { get; set; }


}
