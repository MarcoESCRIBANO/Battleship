using System;
namespace ProjetBattleship
{
    public class Box
    {
        public Box()
        {

        }
		private int touche = 0; // #Touche(2), #Rien(0), #Coule(3), #Plouf(1)
		public bool printBateau;
		Bateaux bateau = null;

		public void affecterUnBateau(Bateaux bateau)
		{
			this.bateau = bateau;
		}

		public void print()
		{
			if (printBateau)
			{
				// afficher case avec les bateau et les toucher (graphique)
			}
			else
			{
				// afficher case avec les toucher (graphique)
			}
		}

		public int tir()
		{
			if (touche == 0) // touche == Rien
			{
				if (bateau != null)
				{
					if (bateau.getState() > 0)
					{
						bateau.touche();
						if (bateau.getState() == 0)
						{
							touche = 3;
						}
						else
						{
							touche = 2;
						}
					}
				}
				else
				{
					touche = 1;
				}
				return touche;
			}
            else
            {
				return -1;
            }
		}
	}
}
