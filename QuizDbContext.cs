using Microsoft.EntityFrameworkCore;

class QuizDbContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Highscore> Highscores { get; set; }

    public QuizDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // options.UseInMemoryDatabase("databas");
        options.UseNpgsql("databas");
    }




    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

}
