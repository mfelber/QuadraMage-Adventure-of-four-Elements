using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinWood : MonoBehaviour
{
    public Animator mainWood;
    public Animator wood;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("WindElementShot"))
        {
            wood.SetBool("fall", true);
            StartCoroutine(fallMainWood());
        }
    }

    IEnumerator fallMainWood()
    {
        yield return new WaitForSeconds(1.5f);
        mainWood.SetBool("fall", true);
    }
}
