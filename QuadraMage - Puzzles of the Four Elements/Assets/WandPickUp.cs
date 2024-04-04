using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WandPickUp : MonoBehaviour
{
    public bool wandIsPickedUp;
    public GameObject wand;
    public GameObject wind;
    

    [SerializeField] private PlayableDirector playPickUpScene;


    private void Start()
    {
        wind.SetActive(false);
    }
    public void pickUpwand()
    {
        wandIsPickedUp = true;
        Destroy(gameObject);
        playPickUpScene.Play();
        wind.SetActive(true);
    }

    public void pickUpEarth()
    {
        wind.SetActive(true);
        Destroy(wand);
    }
}
