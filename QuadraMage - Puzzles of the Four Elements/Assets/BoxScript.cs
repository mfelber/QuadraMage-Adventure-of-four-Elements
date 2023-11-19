using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public float posunNaX = 5f;
    private bool hracNarazil = false;
    private bool hracSaHybe = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hracNarazil = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hracNarazil = false;
            hracSaHybe = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hracNarazil)
        {
           
            float pohyb = Input.GetAxis("Horizontal") * posunNaX * Time.deltaTime;

            if (Mathf.Abs(pohyb) > 0.1f)
            {
                hracSaHybe = true;
                transform.Translate(new Vector3(pohyb, 0, 0));
            }
            else if (hracSaHybe)
            {
 
                hracSaHybe = false;
                transform.Translate(Vector3.zero);
            }
        }
    }

}
