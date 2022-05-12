using System;

namespace AncientWisdomsOpenGL
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new AncientWisdomsGame())
                game.Run();
        }
    }
}
