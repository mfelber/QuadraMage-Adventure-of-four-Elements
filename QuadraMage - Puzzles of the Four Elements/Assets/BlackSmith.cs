using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    
    private enum BlackSmithStates { idle, patrol, warning}
    [SerializeField] private Animator blackSmithAnimator;
    BlackSmithStates states;
    public PlayerMovement PlayerMovement;
   // public Animator anim;
    QuestManager questManager;
    Equipment equipment;
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        equipment = FindObjectOfType<Equipment>();
    }

    // Update is called once per frame
    void Update()
    {
       
       if (questManager.acceptSecondQuest == true)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"),false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Elements"), LayerMask.NameToLayer("Enemy"),false);
            if (equipment.isPlayerMoveEquipmentWithWind)
            {
                blackSmithAnimator.SetBool("check", true);
            }
            else
            {
                blackSmithAnimator.SetBool("check", false);
            }

            
        } else
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Elements"), LayerMask.NameToLayer("Enemy"), true);
        }

        if (equipment.isPlayerMoveEquipment)
        {
            blackSmithAnimator.SetBool("warning", true);
        }
        else
        {
            blackSmithAnimator.SetBool("warning", false);
        }

        if (equipment.eqfall)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Elements"), LayerMask.NameToLayer("Enemy"), true);
        }

    }


    public void eqfall()
    {
        equipment.eqfall = true;
    }
    public void checkForStates()
    {
       

        if (equipment.isPlayerMoveEquipmentWithWind)
        {
            states = BlackSmithStates.patrol;
        } else
        {
            states = BlackSmithStates.idle;
        }

        blackSmithAnimator.SetInteger("state", (int)states);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (questManager.acceptSecondQuest == true)
        {

            if (collision.gameObject.CompareTag("Player"))
            {

                PlayerMovement.HowMuchTimeIsLeft = PlayerMovement.TimeOfKnockBack;
                if (collision.transform.position.x <= transform.position.x)
                {
                    PlayerMovement.knockBackFromR = true;

                }
                if (collision.transform.position.x > transform.position.x)
                {
                    PlayerMovement.knockBackFromR = false;

                }
            }
        }
    }
}
