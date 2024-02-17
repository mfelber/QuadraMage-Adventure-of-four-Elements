using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElement : MonoBehaviour
{

    Inventory inventoryScript;

    public GameObject fireElement;
    public float firespeed;
    
    void Start()
    {
        inventoryScript = GetComponent<Inventory>();
       
        
    }

    public void createFireElement()
    {
        GameObject fireInstance = Instantiate(fireElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * firespeed);
        Destroy(fireInstance, 1);
        Debug.Log("shooting fire element");
    }

    
    
}
