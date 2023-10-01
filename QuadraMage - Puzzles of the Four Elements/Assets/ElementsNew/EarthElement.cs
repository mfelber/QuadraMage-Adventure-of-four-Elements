using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthElement : MonoBehaviour
{
    Inventory inventoryScript;

    public GameObject earthElement;
    public float earthSpeed;
   
    void Start()
    {
        inventoryScript = GetComponent<Inventory>();
    }

    public void createEarthElement()
    {
        GameObject earthInstance = Instantiate(earthElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);
        earthInstance.GetComponent<Rigidbody2D>().AddForce(earthInstance.transform.right * earthSpeed);
        Destroy(earthInstance, 1);
        Debug.Log("shooting earth element");
    }


}
