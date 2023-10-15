using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody rigidbody;
    float damage = 20f;
    float timeToDissapear = 10f;
    float timeElasped = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = transform.forward * speed;

    }

    void Update()
    {
        timeElasped += Time.deltaTime;
        if(timeElasped >= timeToDissapear)
        {
            this.destroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            Health enemyHealth = 
                collision.gameObject.GetComponentInParent<Health>() ? 
                collision.gameObject.GetComponentInParent<Health>() : collision.gameObject.GetComponentInChildren<Health>() ?
                collision.gameObject.GetComponentInChildren<Health>() : collision.gameObject.GetComponent<Health>() ?
                collision.gameObject.GetComponent<Health>() : null;

            if ( enemyHealth )
            {
                enemyHealth.doDamage(this.damage);
                this.destroy();
            }
        }
    }

    private void destroy()
    {
        GameObject.Destroy(gameObject);
    }

}
