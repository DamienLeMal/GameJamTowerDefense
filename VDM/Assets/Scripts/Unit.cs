using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //Spawn Unit
        //V - click and drag from shop
        //V - Preview building and range
        //V - Where can you place it, where you can't
        //V - Set position for unit
        //V - apply SO values
        //V - wait building time and switch out models


    //Shoot at ennemies
        //X - Detect Ennemies
        //X - Fire at ennemies (with so values)
        //X - Ennemies loose hp and die

    //Sell Unit & Upgrade Unit
        //X - Popup that shows stats and button to upgrade and Sell
    
    public UnitSO unitSO;
    public bool isActive;
    public Collider PositionCollider;
    public Collider CombatCollider;
    private GameObject prefab;
    public GameObject tent;
    public UiBar bar;
    public void InitUnit (UnitSO so) {
        isActive = false;
        unitSO = so;
        (CombatCollider as SphereCollider).radius = so.shotRange;
        
        StartCoroutine(ReplaceTent(so.prefab, so.spawnTime));
    }
    private IEnumerator ReplaceTent (GameObject obj, float waitTime) {
        float time = 0;
        while (waitTime > time){
            bar.SetValue(time/waitTime);
            time += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
        isActive = true;
        tent.SetActive(false);
        bar.gameObject.SetActive(false);
        prefab = Instantiate(obj,transform.position,Quaternion.identity,transform);
    }
}
