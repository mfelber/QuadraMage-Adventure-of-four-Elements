using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tnt : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    Player player;
    public bool tntIsActive;
    public bool playerNearTnt;
    //[SerializeField]private GameObject tntPrefab;
    QuestManager questManager;
   



    void Start()
    {
       player = FindObjectOfType<Player>();
        time = 5;
        tntIsActive = false;
        questManager = FindObjectOfType<QuestManager>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("Mast"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("WorkBench"));


        // tntGameObject = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (playerNearTnt && Input.GetKeyDown(KeyCode.E) && sceneName == "Level4")
        {
            tntIsActive = true;
        }

        if (playerNearTnt && Input.GetKeyDown(KeyCode.E) && questManager.acceptFirstQuest == true)
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
            //gameObject.SetActive(false);
            Destroy(gameObject);
           // gameObject.SetActive(false);
        }
        //Debug.Log(time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Luster"))
        {
            tntIsActive = true;
        }
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
