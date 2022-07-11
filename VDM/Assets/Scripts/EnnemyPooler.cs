using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnnemyPooler : MonoBehaviour
{
    public static EnnemyPooler singleton;
    [SerializeField] private EnnemyController _shapePrefab;
    public Vector3 spawnPosition;
    public List<EnnemyController> activeEnnemies;
    public EnnemyPool[] pools;
    public int[][] waves;

    private void Start() {
        singleton = this;


        pools = new EnnemyPool[] {
            EnnemyPool.CreatePool(_shapePrefab,spawnPosition,0),
            EnnemyPool.CreatePool(_shapePrefab,spawnPosition,1),
            EnnemyPool.CreatePool(_shapePrefab,spawnPosition,2)
        };

        waves = new int[][] {
            new int[] {0,0,0,0},
            new int[] {0,0,0,0,0,0,0,0},
            new int[] {0,0,0,0,0,1,1,1},
            new int[] {0,1,0,1,0,1,0,1},
            new int[] {1,1,1,1,1,1},
            new int[] {2},
            new int[] {1,1,1,1,2},
            new int[] {0,0,0,1,1,1,2,2,2},
            new int[] {2,2,2},
            new int[] {2,1,2,1,0,1,2,1,2},
        };

        StartCoroutine(SpawnVague());
    }

    public void Release (EnnemyController ennemy) {
        pools[ennemy.id].Release(ennemy);
    }

    // Optionally override the setup components
    // protected override void GetSetup(EnnemyController shape) {
        // base.GetSetup(shape);
        // shape.transform.position = SpawnPosition;
        // shape.Reset();
        // activeEnnemies.Add(shape);
    // }
// 
    // protected override void ReleaseSetup(EnnemyController shape)
    // {
        // base.ReleaseSetup(shape);
        // activeEnnemies.Remove(shape);
    // }
    int index;
    IEnumerator SpawnVague () {
        while (true) {
            yield return new WaitForSeconds(15f);
            
        }
    }
}