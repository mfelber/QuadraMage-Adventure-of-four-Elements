using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpreadLevel2 : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
   // public GameObject fire3;
    //public GameObject fire4;
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
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            Animator.SetBool("spread", true);
            StartCoroutine(spreadFire(2f));
            //Invoke("back", 2.3f);
            //fire1.SetActive(true);
            //fire2.SetActive(true);
        }
    }

    IEnumerator spreadFire(float cas)
    {
        // Predpokladáme, že kamera je deaktivovaná na za?iatku
       
        yield return new WaitForSeconds(cas);
        //float elapsedTime = 0f;

        /*
        while (elapsedTime < cas)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        */
        // Po?káme 2 sekundy a potom aktivujeme kameru s plynulým efektom
        fire1.gameObject.SetActive(true);
        fire2.gameObject.SetActive(true);
        Animator.SetBool("spread", false);
    }


    public void back ()
    {
        Animator.SetBool("spread", false);
    }
}
