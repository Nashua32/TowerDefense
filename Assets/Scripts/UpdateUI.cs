using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI: MonoBehaviour
{
    public Text moneyText;
    public Text livesText;
    void Update()
    {
        moneyText.text = "€" + PlayerStats.money.ToString();
        livesText.text = PlayerStats.lives + " lives";
    }
}
