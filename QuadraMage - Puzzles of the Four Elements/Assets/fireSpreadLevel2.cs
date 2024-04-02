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
    [SerializeField] Animator waterTank;
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
        Animator.SetBool("spread", false);
        Invoke("fall", 3);
    }


    public void back ()
    {
        Animator.SetBool("spread", false);
    }

    public void fall()
    {
        waterTank.Play("waterTankWithWaterFall");
        fire1.SetActive(false);
        fire2.SetActive(false);
    }
}
