using System;
using UnityEngine;

public class BoxStruct
{

	private int touche = 0; // #Touche(2), #Rien(0), #Coule(3), #Plouf(1)

	public bool printBateau;
	public Bateaux bateau = null;
	public GameObject elem;

	public void affecterUnBateau(Bateaux bateau)
	{

		this.bateau = bateau;
		Console.WriteLine("bateau " + this.bateau.Nom + " affecter");
	}

	public bool haveShip()
	{
		if (bateau != null)
		{
			return true;
		}
		else
		{
			return false;
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