using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckForWeight : MonoBehaviour
{
    public GameObject prava;
    public GameObject lava;

    public Animator Leftanimator;
    public Animator Rightanimator;
    Lava llava;
    RightPlatform rightPlatform;
    LeverBalance leverBalance;
    bool balanceLaucnch;
    private enum Balance { equals, leftMore, RightMore}
    Balance balance;

    void Start()
    {
        llava = lava.GetComponent<Lava>();
        rightPlatform = prava.GetComponent<RightPlatform>();
        leverBalance = FindObjectOfType<LeverBalance>();
        if (llava == null)
        {
            Debug.LogError("Skript Lava nebyl nalezen na objektu lava.");
        }
        balanceLaucnch = true;

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
        

        if(LeverBalance.isLeverOn)
        {
            if (weightLeft > weightRight)
            {
                balance = Balance.leftMore;
                balanceLaucnch = false;
            }

            if (weightRight > weightLeft)
            {
                balance = Balance.RightMore;
            }

            
        }

        
        if (LeverBalance.isLeverOn && balanceLaucnch == false && weightLeft == weightRight)
        {
            leverBalance.DeactivateLeverEqualWeights();
        }






            /*
            else
            {
                Invoke("enableInput", 0.2f);
                PlayerMovement.isInputEnabled = true;
                //StartCoroutine(enableInput());

            }
            */



            Leftanimator.SetInteger("state", (int)balance);
        Rightanimator.SetInteger("state", (int)balance);
    }





    
    /*
    IEnumerator enableInput()
    {
        yield return new WaitForSeconds(2f);
        PlayerMovement.isInputEnabled = true;
    }
    */


    public void setMoved()
    {
        isMoved = false;
    }

    private void rightMoved()
    {
        Rightanimator.SetBool("RightDown", false);
    }
}
