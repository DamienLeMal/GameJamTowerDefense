using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum Display {
    DPS,
    DPC
}

public class ProdButton : MonoBehaviour
{
    public TextMeshProUGUI costDisplay;
    public Display d;

    private void Update() {
        if (d is Display.DPC) {
            costDisplay.text = Player.singleton.upgradeDpcCost.ToString();
            if (Player.singleton.dollards < Player.singleton.upgradeDpcCost)
                costDisplay.color = Color.red;
            else
                costDisplay.color = Color.black;
        }else{
            costDisplay.text = Player.singleton.upgradeDpsCost.ToString();
            if (Player.singleton.dollards < Player.singleton.upgradeDpsCost)
                costDisplay.color = Color.red;
            else
                costDisplay.color = Color.black;
        }
    }
}
