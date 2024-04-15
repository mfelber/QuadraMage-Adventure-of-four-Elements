using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devilAttack : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;   
    public float force;
    private float lifespan;

    void Start()
    {
        lifespan = 3;
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
        lifespan -= Time.deltaTime; 
        if (lifespan < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.1f);
        }

        if (collision.gameObject.CompareTag("WaterElementShot"))
        {
            Destroy(gameObject);
        }
    }

}

    

