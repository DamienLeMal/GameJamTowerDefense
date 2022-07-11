using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitButton : MonoBehaviour
{
    public UnitSO unit;
    public TextMeshProUGUI textMeshPro;
    private int _cost;
    public int cost {
        get {

            return _cost;
        }
        set {
            _cost = value;
            textMeshPro.text = value.ToString();
        }
    }
    private bool _affordable;
    public bool affordable {
        get {
            return _affordable;
        }
        set {
            _affordable = value;
            DisableButton(!_affordable);
        }
    }
    public Image icon;
    private void Start() {
        icon.sprite = unit.icon;
        cost = unit.startCost;
        Player.singleton.onMoneyUpdate += CheckIfAffordable;
    }

    public void CheckIfAffordable () {
        affordable = (Player.singleton.dollards >= cost);
    }

    public GameObject disabledFilter;
    public void DisableButton (bool toggle) {
        disabledFilter.SetActive(toggle);
        if (toggle)
            textMeshPro.color = Color.red;
        else
            textMeshPro.color = Color.black;
    }

    public void UpdatePrice () {
        cost = (int)((float)cost * 1.5f);
    }
}
