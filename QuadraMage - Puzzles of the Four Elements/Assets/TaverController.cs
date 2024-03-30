using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaverController : MonoBehaviour
{
    public GameObject tavernOut, taverIn;
    void Start()
    {
        tavernOut.SetActive(true);
        taverIn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.inBulding == true)
        {
            tavernOut.SetActive(false);
            taverIn.SetActive(true);
        } else
        {
            tavernOut.SetActive(true);
            taverIn.SetActive(false);
        }
    }

   
}
