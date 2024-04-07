using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpreadLevel3 : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public Animator Animator;
    void Start()
    {
        fire1.SetActive(false);
        fire2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot") )
        {
            Animator.SetBool("SpreadFireLevel3",true);
            StartCoroutine(spreadFire(0.7f));
            Destroy(collision.gameObject);
            //Invoke("back", 2.3f);

        }
    }

    IEnumerator spreadFire(float time)
    {


        yield return new WaitForSeconds(time);
        fire1.SetActive(true);
        fire2.SetActive(true);
        //float elapsedTime = 0f;

        /*
        while (elapsedTime < cas)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        */

        //fire1.gameObject.SetActive(true);
        //fire2.gameObject.SetActive(true);
        Animator.SetBool("SpreadFireLevel3", false);
       
    }
}
