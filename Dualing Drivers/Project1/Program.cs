
namespace Project1
{
    class Program
    {
        [System.STAThread]
        static void Main(string[] args)
        {
            using var game = new Project1.Game1();
            game.Run();
        }
    }
}

