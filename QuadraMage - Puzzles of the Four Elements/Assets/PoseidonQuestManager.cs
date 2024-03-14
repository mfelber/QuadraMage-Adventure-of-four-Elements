using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonQuestManager : MonoBehaviour
{
    public GameObject PoseidonNPCQuest1;
    public GameObject PoseidonNPCQuest2;
    public bool poseidonMarmaidQuestCom;
    void Start()
    {
        poseidonMarmaidQuestCom = false;
        PoseidonNPCQuest1.SetActive(false);
        PoseidonNPCQuest2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void quest1Completed()
    {

        poseidonMarmaidQuestCom = true;
        

    }
}
