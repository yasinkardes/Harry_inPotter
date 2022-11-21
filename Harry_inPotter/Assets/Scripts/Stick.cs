using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Stick : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;

    public float radius = 5.0F;
    public float power = 10.0F;

    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;
    float mainTimer;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    public void Naber()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireRate)
        {
            mainTimer += Time.deltaTime * 0.5f;
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange) && hit.transform.tag == "Finish")
            {
                laserLine.SetPosition(1, hit.point);
                Shoot();
                Destroy(hit.transform.gameObject, 2f);
            }
            else 
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }

            StartCoroutine(ShootLaser());
        }
    }

    void Shoot()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 0.05f, ForceMode.Impulse);
                //rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(mainTimer);
        laserLine.enabled = false;
    }
}
