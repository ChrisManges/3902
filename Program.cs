using System;

namespace Homerchu
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new Mario.MarioGame();
            game.Run();
        }
    }
}
