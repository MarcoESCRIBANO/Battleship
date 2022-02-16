using System;
namespace ProjetBattleship
{
    public class Game
    {
        public Game()
        {
        }

		public void start(string NamePlayer1, string NamePlayer2)
		{
			bool InGame = true;
			Player[] players = new Player[] { new Player(NamePlayer1), new Player(NamePlayer2) }; // (possibilité de remplacer par une class Players qui gère l'ensemble des joueurs)
			game(players, InGame);
		}


		public void game(Player[] players, bool InGame)
		{
			int currentPlayer = 0;
			int nbJoueur = players.Length;
			while (InGame)
			{

				//afficherMap();
				if (players[currentPlayer].isFirstTour())
				{
					foreach (Bateaux bateau in players[currentPlayer].bateaux)
					{
						// Début Recupérer coordoneé
						Console.WriteLine("Placer vos bateaux");
						Console.WriteLine("Enter les coordonnée du " + bateau.Nom);
						Console.WriteLine("colonne (A à J):");
						char x = Convert.ToChar(Console.ReadLine());
						Console.WriteLine("ligne (1 à 10):");
						int y = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("sens (haut, bas, droite, gauche):");
						string sens = Console.ReadLine();
						// Fin Recupérer coordoneé
						players[currentPlayer].placerBateau(bateau.Nom, x, y, sens);
					}
					
				}
                else
                {
					Console.WriteLine("Attaquer");
					Console.WriteLine("Enter les coordonnéen où vous souhaitez attaquer");
					Console.WriteLine("colonne (A à J):");
					char x = Convert.ToChar(Console.ReadLine());
					Console.WriteLine("ligne (1 à 10):");
					int y = Convert.ToInt32(Console.ReadLine());
					players[currentPlayer].attaquer(x, y);
				}
				currentPlayer = (currentPlayer + 1) % nbJoueur;
				players[currentPlayer].nextTour();
			}
		}
	}
}
