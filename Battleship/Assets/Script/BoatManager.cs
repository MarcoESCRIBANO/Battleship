using UnityEngine;
using UnityEngine.UI;

public class BoatManager : MonoBehaviour
{
    public static BoatManager instance;

    #region Singleton

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a déja un BoatManager dans la scène");
            return;
        }
        instance = this;
    }
    #endregion


    [SerializeField] private GameObject[] boats;
    [SerializeField] private GameObject[] tirs;
    [SerializeField] private GameObject deathEffectToPlace;
    [SerializeField] private Camera cam1;
    [SerializeField] private Camera cam2;
    [SerializeField] private Button nextButtonPlayer1;
    [SerializeField] private Button nextButtonPlayer2;
    [SerializeField] private GameObject optionUI;

    private GameObject boatToPlace;
    private GameObject tirToPlace;
    private GameObject effectToPlace;
    


    public GameObject GetBoatToPlace(string name)
    {
        foreach (GameObject boat in boats)
        {
            if (boat.name == name)
            {
                boatToPlace = boat;
            }
        }
        return boatToPlace;
    }

    public (GameObject,GameObject,GameObject) GetTirToPlace(string state)
    {
        foreach (GameObject tir in tirs)
        {
            if (tir.name == state)
            {
                tirToPlace = tir;
            }
            if (tir.name == state+ "Particle")
            {
                effectToPlace = tir;
            }
        }
        return (tirToPlace,effectToPlace,deathEffectToPlace);
    }

    public int GetActivePlayer()
    {
        if (cam1.isActiveAndEnabled)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    public void SetActivePlayer()
    {
        if (cam1.isActiveAndEnabled)
        {
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }
        else
        {
            cam2.gameObject.SetActive(false);
            cam1.gameObject.SetActive(true);
        }
    }

    public void InitPlayer()
    {
        optionUI.SetActive(false);
        cam2.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        nextButtonPlayer1.gameObject.SetActive(false);
        nextButtonPlayer2.gameObject.SetActive(false);
    }

    public void EnableButtonNext()
    {
        if (GetActivePlayer() == 0)
        {
            nextButtonPlayer1.gameObject.SetActive(true);
            nextButtonPlayer2.gameObject.SetActive(false);
        }
        else
        {
            nextButtonPlayer1.gameObject.SetActive(false);
            nextButtonPlayer2.gameObject.SetActive(true);
        }
    }

    public bool NextButtonIsActive()
    {
        if (GetActivePlayer() == 0)
        {
            return nextButtonPlayer1.gameObject.activeSelf;
        }
        else
        {
            return nextButtonPlayer2.gameObject.activeSelf;
        }  
    }

    public void OpenOptionUI()
    {
        optionUI.SetActive(true);
    }

    public void CloseOptionUI()
    {
        optionUI.SetActive(false);
    }
}
