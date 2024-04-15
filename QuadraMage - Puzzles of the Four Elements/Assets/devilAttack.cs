using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devilAttack : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public Rigidbody2D playerRB;
    public float force;
    public PlayerMovement PlayerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * force;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Shot"), LayerMask.NameToLayer("Ground"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Shot"), LayerMask.NameToLayer("Shot"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Shot"), LayerMask.NameToLayer("FirstAttack"), true);
    }

    // Update is called once per frame
    public bool hitplayer;
    void Update()
    {
        /*
        if(hitplayer)
        {
            player.transform.position = new Vector2(player.transform.position.x - 0.5f, player.transform.position.y + 0.5f);
            hitplayer = false;
        }
        */

        if (hitplayer)
        {
            playerRB.velocity = new Vector2(-10, 10);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            hitplayer = true;
            Destroy(gameObject, 0.1f);
        }
    }

    
}
