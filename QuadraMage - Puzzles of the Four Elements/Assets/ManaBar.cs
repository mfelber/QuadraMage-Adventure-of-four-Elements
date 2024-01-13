using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    public Slider slider;
    public static bool isEmpty;




   
    public void setMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

   public void setMana(int mana)
    {
        slider.value = mana;
        if(mana <= 0)
        {
            manaIsEmpty();
        }
      
    }

    public void manaIsEmpty()
    {
        isEmpty = true;
        Debug.Log("Nemas manu");
    }

    
    

    
}
