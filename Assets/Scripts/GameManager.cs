using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;

    int numCoins;


    //Public method that will be called from the player' script when it gets the coins (onTrigger)
    public void AddCoin()
    {
        //adding 1
        numCoins++;

        // Interface shows
        textCoin.text = numCoins.ToString() + " mana";
    }
}
