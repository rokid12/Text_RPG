using TextRPG;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character();
            UIManager ui = new UIManager(player);

            ui.ShowIntro();
            ui.ShowMainMenu();
        }
    }
}