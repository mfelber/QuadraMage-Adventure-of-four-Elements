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
            // Pokud invent�? nen� pr�zdn�, za?neme na prvn�m prvku.
            AktualizovatAktualniElement();
        }
    }
    public void PridatDoInventara(Item.ItemData itemData)
    {
        inventar.Add(itemData);
        Debug.Log("Polo�ka " + itemData.itemName + " pridan� do invent�ra.");

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
            Debug.LogWarning("Neplatn� index pro zm?nu polo�ky v invent�?i.");
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


        // Zde m?�ete implementovat logiku pro p?ep�n�n� mezi polo�kami pomoc� ?�sel na kl�vesnici.
        // Nap?�klad:
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ZmenitElement(0); // Zm?na na prvn� polo�ku (?�slo 1).
                   

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ZmenitElement(1); // Zm?na na druhou polo�ku (?�slo 2).
           

        }
        // A tak d�le pro dal�� ?�sla na kl�vesnici a odpov�daj�c� indexy v invent�?i.
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ZmenitElement(2); // Zm?na na druhou polo�ku (?�slo 2).
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ZmenitElement(3); // Zm?na na druhou polo�ku (?�slo 2).
        }
    }

   
}
