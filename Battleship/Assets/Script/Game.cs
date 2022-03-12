using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
	public static Game instance;

	#region Singleton

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Il y a déja un Game dans la scène");
			return;
		}
		instance = this;

	}
	#endregion

	private Player[] players = new Player[] { new Player("Player1"), new Player("Player2") };
	private int nbJoueur;
	private string winner = "";

	[SerializeField] TextMeshProUGUI namePlayer1Text;
	[SerializeField] TextMeshProUGUI namePlayer2Text;

	private void Start()
	{
		nbJoueur = players.Length;
		namePlayer1Text.text = players[0].getName();
		namePlayer2Text.text = players[1].getName();
		InitTurn();
	}

	public Player GetCurrentPlayer()
    {
		return players[BoatManager.instance.GetActivePlayer()];
	}

	public Player GetAdversaire()
	{
		return players[(BoatManager.instance.GetActivePlayer() + 1) % nbJoueur];
	}

	public void NextTurn()
    {
		GetCurrentPlayer().nextTour();
		BoatManager.instance.SetActivePlayer();
        if (GetCurrentPlayer().haveLost())
        {
			winner = GetCurrentPlayer().getName();
			SceneManager.LoadScene("WinningScene");
		}
	}

	public void InitTurn()
	{
		BoatManager.instance.InitPlayer();
	}

	public bool isFirstTour()
    {
		return GetCurrentPlayer().isFirstTour();
    }

	public string GetWinner()
    {
		return winner;
    }
}
