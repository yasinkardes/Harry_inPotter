using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform point;

    public void EnemyShoot()
    {
         GameObject fireball = Instantiate(projectile, point.position, point.rotation) as GameObject;
         Rigidbody rb = fireball.GetComponent<Rigidbody>();
         rb.velocity = transform.forward * 20;
    }
}
