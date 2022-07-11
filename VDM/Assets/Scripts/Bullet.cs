using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    public float collisionRadius;
    private EnnemyController target;

    public Bullet Init (EnnemyController target, UnitSO u) {
        speed = u.shotSpeed;
        damage = u.shotDamage;
        this.target = target;
        return this;
    }

    private void FixedUpdate() {
        if (target is null) return;
        transform.LookAt(target.transform.position,Vector3.up);
        Vector3 direction = target.transform.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (direction.magnitude < collisionRadius * collisionRadius) {
            target.pv -= damage;
            BulletPool.singleton.Release(this);
        }

    }
}
