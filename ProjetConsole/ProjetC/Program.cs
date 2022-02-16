using System;

namespace ProjetBattleship
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("*** Touché Coulé ***");
            Game game = new Game();
            game.start("Marco", "Patricia");
        }
	}
}
