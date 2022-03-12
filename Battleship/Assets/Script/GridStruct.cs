public class GridStruct
{
	public BoxStruct[,] Tab;

	public GridStruct(int size, int playerID)
	{
		Tab = new BoxStruct[size, size];
		for (int rangee = 0; rangee < Tab.GetLength(0); rangee++)
		{
			for (int colonne = 0; colonne < Tab.GetLength(1); colonne++)
			{
				Tab[rangee, colonne] = new BoxStruct();
			}
		}
	}

	public BoxStruct getBox(int x, int y)
	{
		return Tab[x, y];
	}
}