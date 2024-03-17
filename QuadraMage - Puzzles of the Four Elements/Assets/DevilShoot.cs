using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilShoot : MonoBehaviour
{
    public GameObject attack;
    public Transform attackPosition;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    public void shoot()
    {
        Instantiate(attack, attackPosition.position, Quaternion.identity);
    }
}
