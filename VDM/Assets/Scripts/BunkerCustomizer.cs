using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Tiers {
    T0,
    T1,
    T2,
    T3
}
public class BunkerCustomizer : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();
    private GameObject currentBunker;
    private Tiers destruction;
    private Tiers dpc;
    private Tiers dps;
    
    private Dictionary<(Tiers,Tiers,Tiers),GameObject> dico;

    private void Start() {
        destruction = Tiers.T1;
        dico = new Dictionary<(Tiers, Tiers, Tiers), GameObject>() {
            { (Tiers.T0,Tiers.T0,Tiers.T0) , list[0] },
        };
    }
    private void UpdateBunker () {
        currentBunker.SetActive(false);
        GameObject a = dico[(destruction,dpc,dps)];
        currentBunker = a;
        a.SetActive(true);
    }
}
