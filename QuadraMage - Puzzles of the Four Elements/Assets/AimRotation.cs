using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{

    public float maxRotation = 80.0f;
    public float minRotation = 10.0f;
    public float rotationSpeed = 10.0f;

    void Update()
    {
        // Pridaná podmienka, ktorá obmedzuje rotáciu iba okolo osi Z
        float zRotation = transform.rotation.eulerAngles.z;
        zRotation += Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;
        zRotation = Mathf.Clamp(zRotation, minRotation, maxRotation);

        // Nastavenie rotácie iba pre os Z
        transform.rotation = Quaternion.Euler(0, 0, zRotation);
    }
}
