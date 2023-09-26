using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseElements : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WindElement;
    public GameObject FireElement;
    private string itemName;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

   



    public void useFireElement()
    {

        /*
        GameObject fireInstance = Instantiate(FireElement, skriptB.aimPoint.position, skriptB.aimPoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * fireSpeed);
        Destroy(fireInstance, 1); // destroy fire instance after 2 second when player use element
                                  // 
        */
        Debug.Log("strielam fire element");
    }
    public void useWindElement()
    {

        /*
        GameObject fireInstance = Instantiate(FireElement, skriptB.aimPoint.position, skriptB.aimPoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * fireSpeed);
        Destroy(fireInstance, 1); // destroy fire instance after 2 second when player use element
                                  // 
        */

        Debug.Log("strielam wind element");
    }
}
