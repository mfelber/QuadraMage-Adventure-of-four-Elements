using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverRocks : MonoBehaviour
{
    public Animator wallAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leverRoundedRocksScript.isLeverOn)
        {
            Invoke("wallDown", 2);
            wallAnimator.SetBool("leverOn", true);
        }
    }

    public void wallDown()
    {
        wallAnimator.SetBool("leverOn", false);
    }
}
