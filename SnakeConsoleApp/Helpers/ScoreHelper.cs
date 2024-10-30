namespace SnakeConsoleApp.Helpers
{
    public class ScoreHelper
    {
        public static void GetScore(int score)
        {
            Console.SetCursorPosition(2, 22);
            Console.WriteLine($"Score: {score}");
        }
    }
}
