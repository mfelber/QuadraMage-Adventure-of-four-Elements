using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCart : MonoBehaviour
{

   public  Animator animator;
    bool onplatform;
    public Transform Transform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            Transform = collision.transform;
            Transform.SetParent(transform);
            animator.SetBool("go", true);


        }
    }



    public void outofplatform ()
    {
        Transform.SetParent(null);
        Rigidbody2D playerRigidbody = Transform.gameObject.GetComponent<Rigidbody2D>();

        playerRigidbody.AddForce(new Vector2(20f, 10f), ForceMode2D.Impulse);

    }

}
