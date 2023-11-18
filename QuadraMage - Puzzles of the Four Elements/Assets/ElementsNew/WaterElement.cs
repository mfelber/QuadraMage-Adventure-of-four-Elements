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

    public void createWaterElement(Object nullobj)
    {

        // GameObject obj = GameObject.Instantiate<GameObject>(waterElement);


        //  GameObject obj = Instantiate(waterElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);

        //  obj.GetComponent<Rigidbody2D>().AddForce(obj.transform.right * waterSpeed);
        // Destroy(obj, 2);
        Animator anim = GetComponent<Animator>();
        anim.SetBool("WaterBall", true);
        GameObject obj = GameObject.Instantiate<GameObject>(waterElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);
        Destroy(obj, 2);

        Debug.Log("shooting water element");
        
    }

    public void SwitchTransition(Object nullobj)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("WaterBall", false);
    }
}
