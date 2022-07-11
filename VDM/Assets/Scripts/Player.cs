using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public static Player singleton;
    private void Start() {
        singleton = this;
        startPv = pv;
    }
    #region money
    private int _dollards;
    /// <summary>
    /// Dollards per click
    /// </summary>
    public int dollards {
        get  {
            return _dollards;
        }
        set {
            _dollards = value;
            moneyText.text = _dollards.ToString("000000000") + " $";
            onMoneyUpdate.Invoke();
        }
    }
    public TextMeshProUGUI moneyText;
    public event Action onMoneyUpdate;
    public void OnMoneyUpdate () {
        if (onMoneyUpdate is null) return;
        onMoneyUpdate();
    }

    public int dpc;
    /// <summary>
    /// Dollards per seconds
    /// </summary>
    public int dps;
    public void AddDollards (int amount) {
        dollards += amount;
    }

    public void RemoveDollards (int amount) {
        dollards -= amount;
    }

    private float timer;
    private void Update() {
        timer += Time.deltaTime;
        if (timer >= 1) {
            timer = 0;
            AddDollards(dps);
        }
    }
    public void Click () {
        AddDollards(dpc);
    }


    //Upgrades
    public int upgradeDpsCost = 40; //70
    public void UpgradeDps () {
        if (dollards < upgradeDpsCost) return;
        RemoveDollards(upgradeDpsCost);
        dps++;
        upgradeDpsCost = 40+(25+5*dps)*dps;
    }

    public int upgradeDpcCost = 80; //70
    public void UpgradeDpc () {
        if (dollards < upgradeDpcCost) return;
        RemoveDollards(upgradeDpcCost);
        dpc++;
        upgradeDpcCost = 80+(25+100*dpc)*dpc;
    }


    #endregion

    #region life
    public UiBar bar;
    public int pv;
    private int startPv;
    public void RemovePv (int amount) {
        pv -= amount;
        bar.SetValue((float)pv/startPv);
    }

    #endregion

}
