using System;
using UnityEngine;

public class Player
{
	private string Name;
	public Bateaux[] bateaux = new Bateaux[] { new Bateaux("Corvette"), new Bateaux("Torpilleur"), new Bateaux("Fregate"), new Bateaux("Cuirasse"), new Bateaux("Croiseur") };
	public GridStruct grilleJoueur = new GridStruct(10, 1);
	private int nbTours = 0;

	public Player(string Name)
	{
		this.Name = Name;
	}

	public bool placerBateau(string nameBateau, int x, int y, string sens) // (x et y corresponde à l'arrière du bateau)
	{
		for (int id = 0; id < bateaux.Length; id++)
		{
			if (bateaux[id].Nom == nameBateau)
			{
				int X = x;
				int Y = y;
				int xBack = X;
				int yBack = Y;
				int xFront;
				int yFront;
				switch (sens)
				{
					case "haut":
						xFront = X;
						yFront = Y - (bateaux[id].getTaille() - 1);
						if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
						{
							for (int i = Y; i >= yFront; i--)
							{
								if (grilleJoueur.getBox(xFront, i).haveShip())
								{
									Debug.Log("Un bateau se trouve déjà à cet emplacement");
									return true;
								}
							}
							for (int i = Y; i >= yFront; i--)
							{
								grilleJoueur.getBox(xFront, i).affecterUnBateau(bateaux[id]);
								bateaux[id].AddCoordonnée(xFront, i);
							}
							bateaux[id].changeActive();
							return false;
						}
						else
						{
							Debug.Log("Bateau en dehors de la map");
							return true;
						}
					case "bas":
						xFront = X;
						yFront = Y + (bateaux[id].getTaille() - 1);
						if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
						{
							for (int i = Y; i <= yFront; i++)
							{
								if (grilleJoueur.getBox(xFront, i).haveShip())
								{
									Debug.Log("Un bateau se trouve déjà à cet emplacement");
									return true;
								}
							}
							for (int i = Y; i <= yFront; i++)
							{
								grilleJoueur.getBox(xFront, i).affecterUnBateau(bateaux[id]);
								bateaux[id].AddCoordonnée(xFront, i);
							}
							bateaux[id].changeActive();
							return false;
						}
						else
						{
							Debug.Log("Bateau en dehors de la map");
							return true;
						}
					case "droite":

						xFront = X + (bateaux[id].getTaille() - 1);
						yFront = Y;
						if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
						{
							for (int i = X; i <= xFront; i++)
							{
								if (grilleJoueur.getBox(i, yFront).haveShip())
								{
									Debug.Log("Un bateau se trouve déjà à cet emplacement");
									return true;
								}
							}
							for (int i = X; i <= xFront; i++)
							{
								grilleJoueur.getBox(i, yFront).affecterUnBateau(bateaux[id]);
								bateaux[id].AddCoordonnée(i, yFront);
							}
							bateaux[id].changeActive();
							return false;
						}
						else
						{
							Debug.Log("Bateau en dehors de la map");
							return true;
						}
					case "gauche":
						xFront = X - (bateaux[id].getTaille() - 1);
						yFront = Y;
						if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
						{
							for (int i = X; i >= xFront; i--)
							{
								if (grilleJoueur.getBox(i, yFront).haveShip())
								{
									Debug.Log("Un bateau se trouve déjà à cet emplacement");
									return true;
								}
							}
							for (int i = X; i >= xFront; i--)
							{
								grilleJoueur.getBox(i, yFront).affecterUnBateau(bateaux[id]);
								bateaux[id].AddCoordonnée(i, yFront);
							}
							bateaux[id].changeActive();
							return false;
						}
						else
						{
							Debug.Log("Bateau en dehors de la map");
							return true;
						}
					default:
						xFront = X + (bateaux[id].getTaille() - 1);
						yFront = Y;
						if (xBack >= 0 && xBack < 10 && yBack >= 0 && yBack < 10 && xFront >= 0 && xFront < 10 && yFront >= 0 && yFront < 10)
						{
							for (int i = X; i <= xFront; i++)
							{
								if (grilleJoueur.getBox(i, yFront).haveShip())
								{
									Debug.Log("Un bateau se trouve déjà à cet emplacement");
									return true;
								}
							}
							for (int i = X; i <= xFront; i++)
							{
								grilleJoueur.getBox(i, yFront).affecterUnBateau(bateaux[id]);
								bateaux[id].AddCoordonnée(i, yFront);
							}
							bateaux[id].changeActive();
							return false;
						}
						else
						{
							Debug.Log("Bateau en dehors de la map");
							return true;
						}
				}
			}
		}
		return true;
	}

	public int attaquer(int x, int y, Player adversaire)
	{
		int touche;
		int X = x;
		int Y = y;
		touche = adversaire.grilleJoueur.getBox(X, Y).tir();
		return touche;
	}

	public bool isFirstTour()
	{
		if (nbTours == 0)
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

	public bool haveLost()
	{
		foreach (Bateaux bateau in bateaux)
		{
			if (bateau.isAlive())
			{
				return false;
			}
		}
		return true;
	}
}
