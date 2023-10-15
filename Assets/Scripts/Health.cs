using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 500f;
    private void Update()
    {
        if( this.health <= 0f)
        {
            this.OnDeath();
        }
    }

    public void setHealth(float health)
    {
        this.health = health;
    }

    public void setMaxHealth(float health)
    {
        this.maxHealth = health;
    }

    public void doDamage(float damage)
    {
        this.health -= damage;
    }

   void OnDeath()
    {
        GameObject.Destroy(gameObject);
    }
}
