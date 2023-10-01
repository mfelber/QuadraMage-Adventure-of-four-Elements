using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterElement : MonoBehaviour
{
    Inventory inventoryScript;

    public GameObject waterElement;
    public float waterSpeed;
    
    void Start()
    {
        inventoryScript = GetComponent<Inventory>();
    }

   public void createWaterElement()
    {
        GameObject waterInstance = Instantiate(waterElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);
        waterInstance.GetComponent<Rigidbody2D>().AddForce(waterInstance.transform.right * waterSpeed);
        Destroy(waterInstance, 1);
        Debug.Log("shooting water element");
    }
}
