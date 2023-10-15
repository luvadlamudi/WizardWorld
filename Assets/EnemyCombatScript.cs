using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCombatScript : MonoBehaviour
{
    enum ICombatState { easy, medium, hard };
    ICombatState currentState = ICombatState.easy;
    Health health;
    Transform player;
    public float attackRange = 4f;
    public float cooldown = 3f;
    bool attacking;
    Animator animation;
    NavMeshAgent navMeshAgent;
    float currentNavMeshSpeed;
    float slowedDownSpeed = 20f;
    float attackCooldown = 1f;
    public LayerMask playerMask;
    public float damage = 2f;


    void Start()
    {
        health = GetComponent<Health>();
        player = GameObject.Find("Player").transform;
        animation = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHealthAndUpdateCombatState();
        if (!attacking && checkDistanceToPlayer())
        {
            StartCoroutine("startAttacking");
        }
    }

    IEnumerator startAttacking()
    {
        if (!attacking)
        {
            navMeshAgent.speed = slowedDownSpeed;
            attacking = true;
            animation.SetTrigger("Attack");

            Collider[] collision = Physics.OverlapSphere(transform.position, attackRange, playerMask);

            for( int i = 0; i < collision.Length; i++)
            {
                collision[i].gameObject.GetComponent<Health>()?.doDamage(damage);
            }

            yield return new WaitForSeconds(attackCooldown);
            navMeshAgent.speed = currentNavMeshSpeed;
            yield return new WaitForSecondsRealtime(cooldown);
            attacking = false;
        }  
    }

    bool checkDistanceToPlayer()
    {
        if(Vector3.Distance(transform.position,player.position) <= attackRange)
        {
            return true;
        }  
        return false;
    }

    void changeCooldown()
    {
        switch(currentState)
        {
            case ICombatState.easy:
                cooldown = 4f;
                return;
            case ICombatState.medium:
                cooldown = 2f;
                return;
            case ICombatState.hard:
                cooldown = 1f;
                damage = 4f;
                return;
        }
    }

    void checkHealthAndUpdateCombatState()
    {
        if ( health.health < (health.maxHealth * 0.3))
        {
            currentState = ICombatState.hard;
            changeCooldown();
        } else if (health.health < (health.maxHealth * 0.7))
        {
            currentState = ICombatState.medium;
            changeCooldown();
        }
    }
}
