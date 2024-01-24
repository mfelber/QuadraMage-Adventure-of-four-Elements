using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{

    public int keys = 0;

    [SerializeField] private TextMeshProUGUI keyss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HiddenKey"))
        {
            Destroy(collision.gameObject);
            keys++;
            keyss.text = "keys :" + keys;
        }
    }

    public int getKeys()
    {
        return keys;
    }
}
