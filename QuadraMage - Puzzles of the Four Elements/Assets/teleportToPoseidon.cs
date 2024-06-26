using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportToPoseidon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator transition;
    [SerializeField] private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleportPlayer()
    {
        StartCoroutine(teleport());
    }

    public void teleportPlayerToShip()
    {
        StartCoroutine(teleportToShip());
    }

    IEnumerator teleport()
    {
        transition.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector2(-10.89f, 14.70694f);
        transition.SetTrigger("StartTransition");

    }

    IEnumerator teleportToShip()
    {
        transition.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector2(-28.97f, 32.28f);
        transition.SetTrigger("StartTransition");

    }
}
