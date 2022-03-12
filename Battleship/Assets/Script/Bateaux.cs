using UnityEngine;

public class Bateaux
{
	public string Nom;
	public bool alive = true;

	private int Taille;
	private int state;
	private bool active = false;
	private int[,] coordonnées;
	private int currentCoordonnées = 0;

	public Bateaux(string Nom)
	{

		this.Nom = Nom;
		switch (Nom)
		{
			case "Croiseur":
				Taille = 5;
				break;
			case "Cuirasse":
				Taille = 4;
				break;
			case "Fregate":
				Taille = 3;
				break;
			case "Torpilleur":
				Taille = 3;
				break;
			case "Corvette":
				Taille = 2;
				break;
		}
		state = Taille;
		coordonnées = new int[Taille, 2];
	}

	public void AddCoordonnée(int x, int y)
    {
		coordonnées[currentCoordonnées, 0] = x;
		coordonnées[currentCoordonnées, 1] = y;
		currentCoordonnées++;
	}

	public int[,] GetCoordonnées()
	{
		return coordonnées;
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
		if (state == 0)
		{
			death();
		}
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