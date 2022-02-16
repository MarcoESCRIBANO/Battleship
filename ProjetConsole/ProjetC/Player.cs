using System;
namespace ProjetBattleship
{
    public class Player
    {
		private string Name;
		public Bateaux[] bateaux = new Bateaux[] { new Bateaux("Torpilleur"), new Bateaux("Sous-Marin"), new Bateaux("Contre-Torpilleur"), new Bateaux("Croiseur"), new Bateaux("Porte-Avions") };
		Grid grilleJoueur = new Grid(10, 1);
		private int nbTours = 0;

		public Player(string Name)
		{
			this.Name = Name;
		}

		public bool placerBateau(string nameBateau, char x, int y, string sens) // (x et y corresponde à l'arrière du bateau)
		{
			for (int id = 0; id < bateaux.Length; id++)
            {
				if (bateaux[id].Nom == nameBateau)
				{
					int X = Convert.ToByte(x) - 65;
					int Y = y - 1;

					int xBack = X;
					int yBack = Y;
					int xFront;
					int yFront;
					switch (sens)
					{
						case "haut":
							xFront = X;
							yFront = Y - bateaux[id].getTaille() - 1;
							if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
							{
								/*for (int i = Y; i>yFront; i--)
                                {
									if ()
									{

									}
								}*/

								grilleJoueur.placerBateau(bateaux[id], xBack, yBack, xFront, yFront);
								return false;
							}
							else
							{
								Console.WriteLine("Bateaux en dehors de la map");
								return true;
							}
						case "bas":
							xFront = X;
							yFront = Y + bateaux[id].getTaille() - 1;
							if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
							{
								grilleJoueur.placerBateau(bateaux[id], xBack, yBack, xFront, yFront);
								return false;
							}
							else
							{
								Console.WriteLine("Bateaux en dehors de la map");
								return true;
							}
						case "droite":
							xFront = X + bateaux[id].getTaille() - 1;
							yFront = Y;
							if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
							{
								grilleJoueur.placerBateau(bateaux[id], xBack, yBack, xFront, yFront);
								return false;
							}
							else
							{
								Console.WriteLine("Bateaux en dehors de la map");
								return true;
							}
						case "gauche":
							xFront = X - bateaux[id].getTaille() - 1;
							yFront = Y;
							if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
							{
								grilleJoueur.placerBateau(bateaux[id], xBack, yBack, xFront, yFront);
								return false;
							}
							else
							{
								Console.WriteLine("Bateaux en dehors de la map");
								return true;
							}
						default:
							xFront = X + bateaux[id].getTaille() - 1;
							yFront = Y;
							if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
							{
								grilleJoueur.placerBateau(bateaux[id], xBack, yBack, xFront, yFront);
								return false;
							}
							else
							{
								Console.WriteLine("Bateaux en dehors de la map");
								return true;
							}
					}
				}
			}
			return true;
		}

		public void attaquer(char x, int y)
		{
			int touche;
			bool echec = true;
			int X = Convert.ToByte(x) - 65;
			int Y = y - 1;
			while (echec)
            {
				touche = grilleJoueur.getBox(X, Y).tir();
				switch (touche)
				{
					case 1:
						Console.WriteLine("Loupé !");
						echec = false;
						break;
					case 2:
						Console.WriteLine("Touché !");
						echec = false;
						break;
					case 3:
						Console.WriteLine("Coulé !");
						echec = false;
						break;
					default:
						Console.WriteLine("Vous avez déjà tiré ici...");
						echec = true;
						break;
				}
			}
		}

		public bool isFirstTour()
        {
			if(nbTours == 0)
            {
				return true;
			}
            else
            {
				return false;
            }
        }

		public void nextTour()
        {
			nbTours++;
        }

		public int getCurrentTour()
        {
			return nbTours;
        }

		public string getName()
        {
			return Name;
        }

	}
}
