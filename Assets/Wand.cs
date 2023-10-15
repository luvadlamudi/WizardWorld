using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    float bonusMana = 15f;
    float bonusSpeed = 6f;
    float bonusManaRegen = 2f;
    public playerAttributes PA;
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        PA = GetComponentInParent<playerAttributes>();
        PA.setMana(bonusMana);
        PA.setManaRegen(bonusManaRegen);
        inventory = GetComponent<Inventory>();
        inventory.desc = "Bonus Mana: " + bonusMana + " | Bonus Speed: " + bonusSpeed + " | Bonus Mana Regen: " + bonusManaRegen;
    }

    private void OnEnable()
    {
        if( PA != null)
        {
            PA.setMana(bonusMana);
            PA.setManaRegen(bonusManaRegen);
        }
    }

    private void OnDisable()
    {
        PA.setMana(bonusMana * (-1));
        PA.setManaRegen(bonusManaRegen * (-1));
    }

}
