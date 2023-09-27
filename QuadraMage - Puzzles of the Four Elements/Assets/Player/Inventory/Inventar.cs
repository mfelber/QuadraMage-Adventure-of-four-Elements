using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public List<Item.ItemData> inventar = new List<Item.ItemData>();

    private int currentIndex = 0;

    


    void Start()
    {

         
    
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



    public void useWaterElement()
    {

        /*
        GameObject fireInstance = Instantiate(FireElement, skriptB.aimPoint.position, skriptB.aimPoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * fireSpeed);
        Destroy(fireInstance, 1); // destroy fire instance after 2 second when player use element
                                  // 
        */

        Debug.Log("strielam vodny element");
    }
    public void useEarthElement()
    {

        /*
        GameObject fireInstance = Instantiate(FireElement, skriptB.aimPoint.position, skriptB.aimPoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * fireSpeed);
        Destroy(fireInstance, 1); // destroy fire instance after 2 second when player use element
                                  // 
        */

        Debug.Log("strielam zem element");
    }

    public void useWindElement()
    {

        /*
        GameObject fireInstance = Instantiate(FireElement, skriptB.aimPoint.position, skriptB.aimPoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * fireSpeed);
        Destroy(fireInstance, 1); // destroy fire instance after 2 second when player use element
                                  // 
        */

        Debug.Log("strielam wind element");
    }

    public void useFireElement()
    {

        /*
        GameObject fireInstance = Instantiate(FireElement, skriptB.aimPoint.position, skriptB.aimPoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * fireSpeed);
        Destroy(fireInstance, 1); // destroy fire instance after 2 second when player use element
                                  // 
        */
        Debug.Log("strielam fire element");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inventar.Count > 0)
            {
                if (inventar[currentIndex].itemName.Equals("Wind")){
                    useWindElement();
                } else if (inventar[currentIndex].itemName.Equals("Fire")) {
                    useFireElement();
                }
                else if (inventar[currentIndex].itemName.Equals("Water"))
                {
                    useWaterElement();
                }
                else if (inventar[currentIndex].itemName.Equals("Earth"))
                {
                    useEarthElement();
                }

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
