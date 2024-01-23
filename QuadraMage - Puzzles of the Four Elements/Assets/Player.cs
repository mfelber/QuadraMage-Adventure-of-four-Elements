using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int maxMana = 100;   
    public static int currentMana;
    public ManaBar manaBar;

    

    public GameObject player;

    public int level = 1;
    public int hiddenKey = 0;


    public void SavePlayerData()
    {
        Save.SavePlayerData(this);
    }

    public void LoadPlayerData()
    {
        PlayerData data = Save.LoadPlayerSave();

        level = data.level;
        hiddenKey = data.hiddenKey;
    }
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

        
    }

    public void useMana(int mana)
    {
        currentMana -= mana;
        manaBar.setMana(currentMana);
    }

    void setManaToMax()
    {
        if (currentMana == 0 )
        {
            currentMana = 100;
            manaBar.setMana(currentMana);
            ManaBar.isEmpty = false;
        }
       
    }

    public int getValue()
    {
        return hiddenKey;
    }
}
