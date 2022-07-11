using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPath : MonoBehaviour
{
    public static EnnemyPath singleton;
    public List<GameObject> path;
    private void Start() {
        singleton = this;
        path.Reverse();
    }
}
