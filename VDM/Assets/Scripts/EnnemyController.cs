using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyController : MonoBehaviour
{
    public int id;
    public EnnemySO so;
    public int damage;
    public int progress = 0;
    public NavMeshAgent agent;
    public float minDistance;
    public UiBar bar;
    [SerializeField] private int _pv;
    public int pv {
        get {
            return _pv;
        }
        set {
            _pv = value;
            bar.SetValue((float)_pv/so.pv);
            if (_pv <= 0) {
                EnnemyPooler.singleton.Release(this);
            }
                
        }
    }

    public void Reset () {
        damage = so.damage;
        pv = so.pv;
        agent.speed = so.speed;
        progress = 0;
    }

    private void Update() {
        if (progress >= EnnemyPath.singleton.path.Count) {
            EnnemyPooler.singleton.Release(this);
            Player.singleton.RemovePv(damage);
            return;
        }
        agent.destination = EnnemyPath.singleton.path[progress].transform.position;
        float distance = (transform.position - EnnemyPath.singleton.path[progress].transform.position).magnitude;
        if (distance <= minDistance) {
            progress++;
        }
    }
}
