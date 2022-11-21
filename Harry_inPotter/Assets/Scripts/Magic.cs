using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    public GameObject myObject;
    public float openRot, closeRot, Speed;
    public bool opening;


    void Update()
    {
        Vector3 currentRot = myObject.transform.localEulerAngles;

        if (Input.GetMouseButton(0))
        {
            //GetComponent<Animation>().Play();

            myObject.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(openRot, currentRot.y, currentRot.z), Speed * Time.deltaTime);
        }

        else
        {
            myObject.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(closeRot, currentRot.y, currentRot.z), Speed * Time.deltaTime);
        }
    }
}
