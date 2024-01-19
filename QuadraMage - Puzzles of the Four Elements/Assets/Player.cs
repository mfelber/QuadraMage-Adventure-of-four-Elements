using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int maxMana = 100;
    public static int currentMana;
    public ManaBar manaBar;

    public GameObject player;

    

    void Start()
    {
        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (ManaBar.isEmpty)
        {
            Invoke("setManaToMax", 3);

        }

        if (currentMana > 100)
        {
            manaBar.setMana(100);
        }
    }

    public void useMana(int mana)
    {
        currentMana -= mana;
        manaBar.setMana(currentMana);
    }

    void setManaToMax()
    {
        if (currentMana == 0)
        {
            currentMana = 100;
            manaBar.setMana(currentMana);
            ManaBar.isEmpty = false;
        }

    }
}
