using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindElement : MonoBehaviour
{
    Inventory inventoryScript;

    public GameObject windElement;
    public float windSpeed;


    void Start()
    {
        inventoryScript = GetComponent<Inventory>();
    }

    public void createWindElement()
    {
        GameObject windInstance = Instantiate(windElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);
        windInstance.GetComponent<Rigidbody2D>().AddForce(windInstance.transform.right * windSpeed);
        Destroy(windInstance, 1);


        Debug.Log("shooting wind element");
    }

  
}
