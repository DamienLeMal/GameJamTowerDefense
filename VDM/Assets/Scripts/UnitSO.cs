using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit")]
public class UnitSO : ScriptableObject
{
    public GameObject prefab;
    public Mesh mesh;
    public Sprite icon;
    public float shotSpeed;
    public float shotRate;
    public int shotDamage;
    public float spawnTime;
    public float shotRange;
    public int startCost;
}
