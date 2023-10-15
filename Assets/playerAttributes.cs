using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttributes : MonoBehaviour
{
    float maxMana = 50f;
    float mana = 0f;
    float manaRegen = 2f;

    public float fireballManaCost = 10f;
    public float thunderManaCost = 20f;

    public float thunderRange = 5f;
    public float thunderDamage = 100f;

    float speed = 2f;
    float strength = 15f;
    float jumpHeight = 1f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1f)
        {
            mana += manaRegen;
            mana = Mathf.Clamp(mana, 0, maxMana);
            timer = 0;
        }
    }

    public void setCurrentMana(float manaDiff)
    {
        mana += manaDiff;
    }

    public float getMana()
    {
        return maxMana;
    }

    public void setMana(float manaDifference)
    {
        maxMana += manaDifference;
    }

    public float getManaRegen()
    {
        return manaRegen;
    }
            
    public void setManaRegen(float manaDifference)
    {
        manaRegen += manaDifference;
    }

    public float Speed
    {
        get { return this.speed; }
        set { speed = value; }
    }

}
