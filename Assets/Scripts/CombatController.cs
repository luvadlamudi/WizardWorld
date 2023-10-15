using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class CombatController : MonoBehaviour
{
    bool Fireball = false;

    public Camera cam;

    public enum selectableSpells { Fireball, Thunder };

    public LayerMask enemyLayer;

    selectableSpells selectedSpell;

    bool attacking;

    Transform attackPosition;

    public GameObject fireballObject;

    LightningBoltScript lightningBoltScript;

    public playerAttributes PA;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        PA = GetComponent<playerAttributes>();
        selectedSpell = selectableSpells.Thunder;
        lightningBoltScript = GameObject.Find("SimpleLightningBoltPrefab").GetComponent<LightningBoltScript>();
        attackPosition = GameObject.Find("wand").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!attacking)
            {
                switch (selectedSpell)
                {
                    case selectableSpells.Fireball:
                        if (PA.getMana() >= PA.fireballManaCost)
                        {
                            PA.setCurrentMana(PA.fireballManaCost * -1);
                            attacking = true;
                            StartCoroutine("fireballAttack");
                        }
                        break;
                    case selectableSpells.Thunder:
                        if (PA.getMana() >= PA.thunderManaCost)
                        {
                            PA.setCurrentMana(PA.thunderManaCost * -1);
                            attacking = true;
                            StartCoroutine("thunderAttack");
                        }
                        break;
                }
            }
        }
    }

    IEnumerator fireballAttack()
    {
        if (!Fireball)
        {
            Fireball = true;
            animator.SetBool("Fireball", true);

            Instantiate(fireballObject, transform.position + transform.forward, transform.rotation);

            yield return new WaitForSecondsRealtime(1f);

            Fireball = false;
            attacking = false;
            animator.SetBool("Fireball", false);
        }
    }

    IEnumerator thunderAttack()
    {
        Debug.Log("THUNDER");
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay( new Vector3(.5f,.5f,0));
        Debug.DrawRay(cam.gameObject.transform.position, cam.gameObject.transform.forward * 1000f, Color.red, 10f);
        if(Physics.Raycast(ray, out hit, PA.thunderRange * 10, enemyLayer))
        {
            GameObject enemyLocation = hit.collider.gameObject;
            Debug.Log(enemyLocation.name);
            lightningBoltScript.EndObject = enemyLocation;
            lightningBoltScript.ManualMode = false;
            Health enemyHealth = enemyLocation.GetComponent<Health>();
            if(enemyHealth != null)
            {
                enemyHealth.doDamage(PA.thunderDamage);
            }
        }
        yield return new WaitForSecondsRealtime(0.5f);

        StartCoroutine("thunderCooldown");
    }

    IEnumerator thunderCooldown()
    {
        lightningBoltScript.ManualMode = true;
        yield return new WaitForSecondsRealtime(8f);
        attacking = false;
    }
}
