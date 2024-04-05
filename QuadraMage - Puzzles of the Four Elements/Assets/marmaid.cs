using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marmaid : MonoBehaviour
{
    // Start is called before the first frame update
    teleportToPoseidon TeleportToPoseidon;
    private PoseidonQuestManager poseidonQuestManager;
    private QuestManager questManager;
   
    void Start()
    {
        TeleportToPoseidon = FindObjectOfType<teleportToPoseidon>();
        poseidonQuestManager = FindObjectOfType<PoseidonQuestManager>();
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("EarthElementShot") && poseidonQuestManager.poseidonMarmaidQuestCom == false)
                 {
          
                TeleportToPoseidon.teleportPlayer();
                poseidonQuestManager.poseidonMarmaidQuestCom = true;
               
            }
            
       
            
        
    }
}
