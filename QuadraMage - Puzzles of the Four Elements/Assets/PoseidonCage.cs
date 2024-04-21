using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonCage : MonoBehaviour
{
    // Start is called before the first frame update
    QuestManager questManager;
    public List<GameObject> itemsToSpawn = new List<GameObject>();
    public GameObject destroy;
   
    
    public bool pirateIsFree;
    public Animator animator;
    [SerializeField] public Animator tntBarrel;
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        pirateIsFree = false;
        destroy.SetActive(true);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pirateIsFree)
        {
            
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
           
        }
    }

    public void showBarrel()
    {
        tntBarrel.Play("showBarrel");
        Invoke("desibleAnimator", 0.6f);
        
    }

    public void desibleAnimator()
    {
       
        tntBarrel.enabled = false;
       
    }
}
