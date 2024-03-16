using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopRockLevel4Script : MonoBehaviour
{
    public string tntObjectName;
    tnt Tnt;
    public bool nearStone;

    void Start()
    {
        GameObject tntObject = GameObject.Find(tntObjectName);
        Tnt = tntObject.GetComponent<tnt>();
        nearStone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nearStone && Tnt.time < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == tntObjectName)
        {
            Debug.Log("kolizia");
            nearStone = true;
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == tntObjectName)
        {
            //Debug.Log("kolizia");
            nearStone = false;
        }
    }
    */
}
