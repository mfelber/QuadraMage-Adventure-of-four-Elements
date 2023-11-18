using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] ParticleSystem cloudParticles;
    private bool isOnCloud = false;


   

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isOnCloud = true;
            cloudParticles.Play();
            
           
        }
    }

 


}