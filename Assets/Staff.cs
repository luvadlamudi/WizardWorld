using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    float bonusMana = 10f;
    float bonusSpeed = 5f;
    float bonusManaRegen = 1f;
    public playerAttributes PA;
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        PA = GetComponentInParent<playerAttributes>();
        PA.setMana(bonusMana);
        PA.setManaRegen(bonusManaRegen);
        PA.Speed += bonusSpeed;
        inventory = GetComponent<Inventory>();
        inventory.desc = "Bonus Mana: " + bonusMana + " | Bonus Speed: " + bonusSpeed + " | Bonus Mana Regen: " + bonusManaRegen;
    }

    private void OnEnable()
    {
        if( PA != null)
        {
            PA.setMana(bonusMana);
            PA.setManaRegen(bonusManaRegen);
            PA.Speed += bonusSpeed;
        }
    }

    private void OnDisable()
    {
        PA.setMana(bonusMana * (-1));
        PA.setManaRegen(bonusManaRegen * (-1));
        PA.Speed -= bonusSpeed;
    }

}


