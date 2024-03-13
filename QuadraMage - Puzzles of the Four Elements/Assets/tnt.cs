using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tnt : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    Player player;
    public bool tntIsActive;
    public bool playerNearTnt;
    //[SerializeField]private GameObject tntPrefab;

    
    void Start()
    {
       player = FindObjectOfType<Player>();
        time = 5;
        tntIsActive = false;

       // tntGameObject = GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearTnt && Input.GetKeyDown(KeyCode.E))
        {
            tntIsActive = true;
        }

        if (tntIsActive)
        {
            time -= Time.deltaTime;
        }
            


        if(time < 0)
        {
            tntIsActive = false;
            Destroy(gameObject);
        }
        Debug.Log(time);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearTnt = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearTnt = false;
        }
    }
}
