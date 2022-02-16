using System;
namespace ProjetBattleship
{
    public class Bateaux
    {
		public string Nom;
		private int Taille;
		public bool alive = true;
		private int state;
		private bool active = false;

		public Bateaux(string Nom)
		{
			this.Nom = Nom;
			switch (Nom)
			{
				case "Porte-Avions":
					Taille = 5;
					break;
				case "Croiseur":
					Taille = 4;
					break;
				case "Contre-Torpilleur":
					Taille = 3;
					break;
				case "Sous-Marin":
					Taille = 3;
					break;
				case "Torpilleur":
					Taille = 2;
					break;
			}
			state = Taille;
		}

		public void afficherBateau(int xBack = -1, int yBack = -1, int xFront = -1, int yFront = -1)
		{
			if (xBack == -1 || yBack == -1 || xFront == -1 || yFront == -1)
			{
				// afficher sur le côté
			}
			else
			{
				// afficher au bonne endroit 
			}
		}

		public bool isAlive()
		{
			return alive;
		}

		public void death()
		{
			alive = false;
		}

		public void touche()
		{
			state -= 1;
		}

		public int getState()
		{
			return state;
		}

		public int getTaille()
		{
			return Taille;
		}

		public bool getActive()
        {
			return active;
        }

		public void changeActive()
        {
			active = !active;
        }
	}
}
