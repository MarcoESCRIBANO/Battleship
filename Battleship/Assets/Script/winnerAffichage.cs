using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class winnerAffichage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winnerText;
    void Start()
    {
        winnerText.text = "Congratulation !\n" + Game.instance.GetWinner() + " won";
    }
}
