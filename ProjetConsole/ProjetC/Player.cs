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

		public void placerBateau(string nameBateau, char x, int y, string sens) // (x et y corresponde à l'arrière du bateau)
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
							yFront = Y + bateaux[id].getTaille();
							break;
						case "bas":
							xFront = X;
							yFront = Y - bateaux[id].getTaille();
							break;
						case "droite":
							xFront = X + bateaux[id].getTaille();
							yFront = Y;
							break;
						case "gauche":
							xFront = X - bateaux[id].getTaille();
							yFront = Y;
							break;
						default:
							xFront = X + bateaux[id].getTaille();
							yFront = Y;
							break;
					}
					if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
					{
						grilleJoueur.placerBateau(bateaux[id], xBack, yBack, xFront, yFront);
					}
					else
					{
						Console.WriteLine("Bateaux en dehors de la map");
					}
				}
			}
		}

		public void attaquer(char X, int Y)
		{

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
