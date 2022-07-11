using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : PoolerBase<Bullet>
{
    public static BulletPool singleton;
    [SerializeField] private Bullet _shapePrefab;
    public Vector3 SpawnPosition;

    private void Start() {
        singleton = this;
        InitPool(_shapePrefab);
    }

    // Optionally override the setup components
    protected override void GetSetup(Bullet shape) {
        base.GetSetup(shape);
        shape.transform.position = SpawnPosition;
    }
}
