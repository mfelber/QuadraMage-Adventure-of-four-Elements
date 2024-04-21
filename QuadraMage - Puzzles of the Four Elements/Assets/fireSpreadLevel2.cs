using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpreadLevel2 : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
   
    public Animator Animator;
    [SerializeField] Animator waterTank;
    QuestManager questManager;
    public GameObject fireSpreadObject;
    void Start()
    {
        fire1.SetActive(false);
        fire2.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
    }

   
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot") && questManager.acceptThirdQuest == true)
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
