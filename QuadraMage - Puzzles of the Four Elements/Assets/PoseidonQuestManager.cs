using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class PoseidonQuestManager : MonoBehaviour
{
    public GameObject PoseidonNPCQuest1;
    public GameObject PoseidonNPCQuest2;
    public bool poseidonMarmaidQuestCom;
    [SerializeField] private List<GameObject> questItems = new List<GameObject>();
    void Start()
    {
        poseidonMarmaidQuestCom = false;
        PoseidonNPCQuest1.SetActive(false);
        PoseidonNPCQuest2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
            if (poseidonMarmaidQuestCom == true)
            {
                for (int i = 0; i < questItems.Count; i++)
                {
                    questItems[i].SetActive(false);
                }
            }
        
    }


    public void quest1Completed()
    {

        poseidonMarmaidQuestCom = true;
        

    }
}
