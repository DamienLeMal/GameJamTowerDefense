using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombatManager : MonoBehaviour
{
    public Unit unit;
    private float time;
    private void Update() {
        if (!unit.isActive) return;
        time += Time.deltaTime;
        if (time >= unit.unitSO.shotRate){
            Fire();
            time = 0;
        }
    }

    private void Fire () {
        //if (ennemiesInView.Count == 0) return;
        if (EnnemyPooler.singleton.activeEnnemies.Count == 0) return;
        //Choose target, should shoot the ennemy closer to the base
        int maxProgress = 0;
        EnnemyController newTarget = null;
        foreach (EnnemyController e in EnnemyPooler.singleton.activeEnnemies) {
            float dist = Vector3.Distance(transform.position,e.transform.position);
            if (dist > unit.unitSO.shotRange) continue;
            if (e.progress > maxProgress) {
                maxProgress = e.progress;
                newTarget = e;
            }
        }
        if (newTarget is null) return;
        Vector3 lookatPlane = newTarget.transform.position;
        lookatPlane.y = this.transform.position.y;
        unit.transform.LookAt(lookatPlane);
        Bullet b = BulletPool.singleton.Get();
        b.transform.position = transform.position;
        b.Init(newTarget, unit.unitSO);
    }
}
