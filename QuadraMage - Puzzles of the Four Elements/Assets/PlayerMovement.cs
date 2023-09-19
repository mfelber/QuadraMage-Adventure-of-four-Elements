using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Player;
    public float runSpeed = 40f;
    public float Horizontal;
   
  
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

      
    }

    private void FixedUpdate()
    {
        Player.velocity = new Vector2( Horizontal * runSpeed, Player.velocity.y);
    }

}
