using System;
namespace ProjetBattleship
{
    public class Grid
    {
		int player;
		Box[,] Tab;
		public Grid(int size, int playerID)
		{
			player = playerID;
			Tab = new Box[size, size];
		}

		public Box getBox(string x, int y) // ex : ("J",3)
		{
			return Tab[Convert.ToInt32(x) - 65, y - 1];
		}

		public Box getBox(int x, int y) // pour opération interne déjà traduite en int
		{
			return Tab[x, y];
		}

		public void printGridWithShip()
		{
			foreach (Box elem in Tab)
			{
				elem.printBateau = true;
				elem.print();
			}
		}

		public void printGridWithoutShip()
		{
			foreach (Box elem in Tab)
			{
				elem.printBateau = false;
				elem.print();
			}
		}

		public void placerBateau(Bateaux bateau, int xBack, int yBack, int xFront, int yFront) //   (À faire) non superposé
		{
			bateau.changeActive();
		}
	}
}
