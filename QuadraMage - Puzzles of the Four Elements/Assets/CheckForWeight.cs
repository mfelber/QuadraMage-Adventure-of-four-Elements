using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class CheckForWeight : MonoBehaviour
{
    public GameObject prava;
    public GameObject lava;

    public Animator Leftanimator;
    public Animator Rightanimator;
    Lava llava;
    RightPlatform rightPlatform;

    private enum Balance { equals, leftMore, RightMore}
    Balance balance;

    void Start()
    {
        llava = lava.GetComponent<Lava>();
        rightPlatform = prava.GetComponent<RightPlatform>();
        if (llava == null)
        {
            Debug.LogError("Skript Lava nebyl nalezen na objektu lava.");
        }
    }
    private bool addedOnce = false;
    private bool isMoved = false;

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(llava.getWeight);
        float weightLeft = llava.getWeight;
        float weightRight = rightPlatform.getWeight;

        UpdateBalance();
        
        /*
        if (weightLeft > weightRight)
        {
           
            //Leftanimator.SetBool("LeftUp",true);
            //Rightanimator.SetBool("RightUp",true);
           // isMoved = true;
            //Invoke("rightMoved", 1.2f);
            // P?idat pouze jednou hodnotu k pozici Y
            //prava.transform.position = new Vector2(prava.transform.position.x, prava.transform.position.y + 1);

            // Nastavit, že už bylo p?idáno
            //addedOnce = true;
        } 

        if (weightLeft == weightRight)
        {
            

            //
            //if(isMoved == true)
            //{
                //Rightanimator.SetBool("RightUp", false);
            //    Rightanimator.SetBool("RightDown", true);
               
              //  Invoke("setMoved", 1.2f);

           // }
           
        }
        */
       
    }

    public void UpdateBalance()
    {
        float weightLeft = llava.getWeight;
        float weightRight = rightPlatform.getWeight;
        

        if (weightLeft == weightRight)
        {
            balance = Balance.equals;
        }

        if (weightLeft > weightRight)
        {
            balance = Balance.leftMore;
        }

        if (weightRight > weightLeft)
        {
            balance = Balance.RightMore;
        }

        Leftanimator.SetInteger("state", (int)balance);
        Rightanimator.SetInteger("state", (int)balance);
    }

    public void setMoved()
    {
        isMoved = false;
    }

    private void rightMoved()
    {
        Rightanimator.SetBool("RightDown", false);
    }
}
