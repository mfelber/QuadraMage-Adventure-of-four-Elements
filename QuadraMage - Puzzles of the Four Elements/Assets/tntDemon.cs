using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tntDemon : MonoBehaviour
{
    public float time;
    DemonScript demonScript;
    public bool tntIsActive;
    public List<GameObject> bridgeParts = new List<GameObject>();
    public bool playerInRange;
    void Start()
    {
        demonScript = FindObjectOfType<DemonScript>();
        tntIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (DemonScript.playerInRange)
        {
            tntIsActive = true;
        }

        if (tntIsActive)
        {
            time -= Time.deltaTime;
        }

        if (time < 0)
        {
            tntIsActive = false;
            Destroy(gameObject);

            for (int i = 0; i < bridgeParts.Count; i++)
            {
                bridgeParts[i].SetActive(false);
            }
            

        }
    }

    
}
