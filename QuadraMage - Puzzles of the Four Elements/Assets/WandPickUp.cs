using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WandPickUp : MonoBehaviour
{
    public bool wandIsPickedUp;
    public GameObject wand;
    public GameObject wind;
    public GameObject finishObject;
    

    [SerializeField] private PlayableDirector playPickUpScene;


    private void Start()
    {
        wind.SetActive(false);
        finishObject.SetActive(false);
    }

    private void Update()
    {
        if(wandIsPickedUp)
        {
            finishObject.SetActive(true);
        }
    }
    public void pickUpwand()
    {
     

        wind.SetActive(true);
        Destroy(wand);
        wandIsPickedUp = true;
    }

    public void pickUpEarth()
    {
        wind.SetActive(true);
        Destroy(wand);
        wandIsPickedUp = true;
    }
}
