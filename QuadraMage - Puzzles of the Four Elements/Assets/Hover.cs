using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Cinemachine.DocumentationSortingAttribute;

public class HoverManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject Tip;

    private int level;
    private int hiddenKey;
    void Start()
    {


        LoadPlayerData();
        Debug.LogError(level);
        Debug.LogError(hiddenKey);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       if (hiddenKey < 4 )
        {
            Tip.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tip.SetActive(false);
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
        else
        {
            Debug.LogError("Failed to load player data.");
        }

    }
}
