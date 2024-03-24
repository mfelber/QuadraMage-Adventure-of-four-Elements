using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WandPickUp : MonoBehaviour
{
    public bool wandIsPickedUp;
    public GameObject wand;

    [SerializeField] private PlayableDirector playPickUpScene;

    public void pickUpwand()
    {
        wandIsPickedUp = true;
        Destroy(gameObject);
        playPickUpScene.Play();

    }
}
