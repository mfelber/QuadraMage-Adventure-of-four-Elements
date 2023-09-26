using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public List<Item.ItemData> inventar = new List<Item.ItemData>();

    private int currentIndex = 0;

    PlayerUseElements skriptB;


    void Start()
    {

         GameObject objektSakriptomB = GameObject.Find("Player");
         skriptB = objektSakriptomB.GetComponent<PlayerUseElements>();
    
        if (inventar.Count > 0)
        {
            // Pokud inventá? není prázdný, za?neme na prvním prvku.
            AktualizovatAktualniElement();
        }
    }
    public void PridatDoInventara(Item.ItemData itemData)
    {
        inventar.Add(itemData);
        Debug.Log("Položka " + itemData.itemName + " pridaná do inventára.");

        currentIndex = inventar.Count - 1;

        if(inventar.Count == 1)
        {
            AktualizovatAktualniElement();
        }    
        

       
    }

    public void ZmenitElement(int index)
    {
        if (index >= 0 && index < inventar.Count)
        {
            currentIndex = index;
            AktualizovatAktualniElement();
            
            
        }
        else
        {
            Debug.LogWarning("Neplatný index pro zm?nu položky v inventá?i.");
        }

        
    }

    private void AktualizovatAktualniElement()
    {

        Debug.Log("Mas v ruke element : " + inventar[currentIndex].itemName);
    }

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inventar.Count > 0)
            {
                
               // shootElement(inventar[currentIndex].itemName);
            }
            else
            {
                Debug.Log("Inventory is Empty you cant shoot");
            }
        }


        // Zde m?žete implementovat logiku pro p?epínání mezi položkami pomocí ?ísel na klávesnici.
        // Nap?íklad:
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ZmenitElement(0); // Zm?na na první položku (?íslo 1).
                   

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ZmenitElement(1); // Zm?na na druhou položku (?íslo 2).
           

        }
        // A tak dále pro další ?ísla na klávesnici a odpovídající indexy v inventá?i.
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ZmenitElement(2); // Zm?na na druhou položku (?íslo 2).
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ZmenitElement(3); // Zm?na na druhou položku (?íslo 2).
        }
    }

   
}
