using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAIMovement : MonoBehaviour
{
    Vector3 point1;
    Vector3 point2;
    Vector3 current;

    float aggroStoppingDistance = 3.5f;
    float nonAggroStoppingDistance = 0f;

    bool hasTarget;

    float aggroRange = 15f;
    float loseAggro = 20f;

    Transform player;

    NavMeshAgent pilot;

    // Start is called before the first frame update
    void Start()
    {
        pilot = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        randomizePoints();

        current = point2;
        
        pilot.SetDestination(current);
        pilot.stoppingDistance = nonAggroStoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < aggroRange)
        {
            hasTarget = true;
            pilot.stoppingDistance = aggroStoppingDistance;
            pilot.SetDestination(player.position);
        } else
        {
            if (pilot.remainingDistance <= 2f && !hasTarget)
            {
                current = current == point1 ? point2 : point1;
                pilot.SetDestination(current);
            }
            else if (hasTarget && Vector3.Distance(player.position, transform.position) > loseAggro)
            {
                hasTarget = false;
                pilot.stoppingDistance = nonAggroStoppingDistance;
                randomizePoints();
            }
        }
    }

    void randomizePoints()
    {
        point1 = new Vector3(Random.Range(transform.position.x - 15, transform.position.x + 15), 0, Random.Range(transform.position.z - 5, transform.position.z + 10));
        point2 = new Vector3(Random.Range(transform.position.x-10, transform.position.x + 5), 0, Random.Range(transform.position.z-5, transform.position.z + 10));
    }

}
