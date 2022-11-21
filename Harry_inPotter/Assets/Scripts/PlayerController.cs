using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 40f;
    float verticalInput;
    float horizontalInput;
    void Start()
    {

    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical"); // Aşağı ve Yukarı
        horizontalInput = Input.GetAxis("Horizontal"); // Sağa ve Sola

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput); // İleri Doğru İlerler
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput); // Sağa ve Sola yumuşak dönüşler yapar
    }
}
