using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonCage : MonoBehaviour
{
    // Start is called before the first frame update
    QuestManager questManager;
    public List<GameObject> itemsToSpawn = new List<GameObject>();
    public GameObject destroy;
   
    public GameObject tntBarrel;
    bool pirateIsFree;
    public Animator animator;   
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        pirateIsFree = false;
        destroy.SetActive(true);
        
        tntBarrel.SetActive(true);
        /*
        for (int i = 0; i < itemsToSpawn.Count; i++)
        {
            itemsToSpawn[i].SetActive(false);
     
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (pirateIsFree)
        {
            /*
            for (int i = 0; i < itemsToSpawn.Count; i++)
            {
                itemsToSpawn[i].SetActive(true);

            }
            */
            destroy.SetActive(false);
            
            animator.Play("PirateInCageGoToShip");
            Invoke("showBarrel",2.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WaterElementShot"))
        {
            questManager.quest3Completed();
            pirateIsFree = true;
            //Destroy(collision.gameObject);
        }
    }

    public void showBarrel()
    {
        tntBarrel.SetActive(true);
    }
}
