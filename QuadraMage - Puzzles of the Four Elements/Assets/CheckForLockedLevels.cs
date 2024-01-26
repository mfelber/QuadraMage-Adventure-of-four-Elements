using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckForLockedLevels : MonoBehaviour 
{
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;

    private int level;
    private int hiddenKey;
    private void Start()
    {
        LoadPlayerData();
       
    }

    

    // Update is called once per frame
    void Update()
    {
              
        if (level == 1)
        {
            level1.enabled = true;
        } 
        
        if (level != 2)
        {
            level2.enabled = false;
        }
        else
        {
            level2.enabled = true;
        }

        if (level != 3)
        {
            level3.enabled = false;
        }
        else
        {
            level3.enabled = true;
        }
        if (level != 4)
        {
            level4.enabled = false;
        }
        else
        {
            level4.enabled = true;
        }
        if (level != 5)
        {
            level5.enabled = false;
        }
        else
        {
            level5.enabled = true;
        }
        

    }

    public void LoadPlayerData()
    {
        //PlayerData data = Save.LoadPlayerSave();

        //level = data.level;
        //hiddenKey = data.hiddenKey;


        PlayerData data = Save.LoadPlayerSave();

        if (data != null)
        {
            level = data.level;
            hiddenKey = data.hiddenKey;
            Debug.Log("Player data loaded. Level: " + level + ", Hidden Key: " + hiddenKey);
        }
        

    }
}
