using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float Force;
    public float Radius;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 explotionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explotionPos, Radius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(Force, explotionPos, Radius, 0.05f, ForceMode.Impulse);
            }
        }
    }
}
