using Microsoft.EntityFrameworkCore;

class QuizDbContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Highscore> Highscores { get; set; }

    public QuizDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=password;");
    }




    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

}
