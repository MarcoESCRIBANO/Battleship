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
			Console.WriteLine("Nombre de Joueur : " + nbJoueur);
			while (InGame)
			{
				Console.WriteLine("C'est à " + players[currentPlayer].getName() + " de jouer");
				//afficherMap();
				if (players[currentPlayer].isFirstTour())
				{
					bool placer;
					char x;
					int y;
					string sens;
					Console.WriteLine("Placer vos bateaux");
					foreach (Bateaux bateau in players[currentPlayer].bateaux)
					{
						placer = true;
                        
                        while (placer)
                        {
							// Début Recupérer coordoneé

							Console.WriteLine("Enter les coordonnée du " + bateau.Nom + " (" + bateau.getTaille() + " cases)");
							Console.WriteLine("colonne (A à J):");
							x = Convert.ToChar(Console.ReadLine());
							Console.WriteLine("ligne (1 à 10):");
							y = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("sens (haut, bas, droite, gauche):");
							sens = Console.ReadLine();

							// Fin Recupérer coordoneé
							placer = players[currentPlayer].placerBateau(bateau.Nom, x, y, sens);
						}

					}
					
				}
                else
                {
					bool attaquer = true;
                    while (attaquer)
                    {
						Console.WriteLine("Attaquer");
						Console.WriteLine("Enter les coordonnéen où vous souhaitez attaquer");
						Console.WriteLine("colonne (A à J):");
						char x = Convert.ToChar(Console.ReadLine());
						Console.WriteLine("ligne (1 à 10):");
						int y = Convert.ToInt32(Console.ReadLine());
						attaquer = players[currentPlayer].attaquer(x, y, players[(currentPlayer + 1) % nbJoueur]);
					}
				}
				players[currentPlayer].nextTour();
				currentPlayer = (currentPlayer + 1) % nbJoueur;
				if (players[currentPlayer].haveLost())
				{
					InGame = false;
					Console.WriteLine(players[(currentPlayer + 1) % nbJoueur].getName() + " a gagné");
				}
			}
		}
	}
}
