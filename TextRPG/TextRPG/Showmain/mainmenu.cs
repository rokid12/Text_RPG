using TextRPG;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            UIManager.Instance.ShowIntro();
            Console.WriteLine("\n\n시작하려면 아무키나 입력하세요...");
            Console.ReadKey();
            Console.SetCursorPosition(0, Console.CursorTop);

            GameManager.Instance.InitGameManager();
            UIManager.Instance.ShowMainMenu();
        }
    }
}