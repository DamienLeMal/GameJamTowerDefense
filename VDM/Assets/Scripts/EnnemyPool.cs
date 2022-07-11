using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPool : PoolerBase<EnnemyController>
{
    public static EnnemyPool CreatePool (EnnemyController prefab, Vector3 spawnPosition, int index) {

        GameObject go =  new GameObject("Pool of " + prefab.name);
        EnnemyPool pool = go.AddComponent<EnnemyPool>();
        pool.Init(prefab,spawnPosition,index);
        return pool;
    }
    private Vector3 spawnPosition;
    private int poolIndex;
    public void Init (EnnemyController prefab, Vector3 spawnPosition, int index) {
        this.spawnPosition = spawnPosition;
        this.poolIndex = index;
        InitPool(prefab);
    }

    // Optionally override the setup components
    protected override void GetSetup(EnnemyController shape) {
        base.GetSetup(shape);
        shape.transform.position = spawnPosition;
        shape.Reset();
        shape.id = poolIndex;
        EnnemyPooler.singleton.activeEnnemies.Add(shape);
    }

    protected override void ReleaseSetup(EnnemyController shape)
    {
        base.ReleaseSetup(shape);
        EnnemyPooler.singleton.activeEnnemies.Remove(shape);
    }
}
