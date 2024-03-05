using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    
    private enum BlackSmithStates { idle, patrol, warning}
    [SerializeField] private Animator blackSmithAnimator;
    BlackSmithStates states;
    public PlayerMovement PlayerMovement;
    public Animator anim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkForStates();
        if (ArmorStand.isPlayerMoveWithArmorStand)
        {
            blackSmithAnimator.SetBool("check", true);
        } else
        {
            blackSmithAnimator.SetBool("check", false);
        }

    }

    public void checkForStates()
    {
       

        if (ArmorStand.isPlayerMoveWithArmorStand)
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("kolizia");
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
