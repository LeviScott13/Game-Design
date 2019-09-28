//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kamikaze : EnemyBase
{
    public Transform[] destinationPoints;
    public NavMeshAgent navAgent;

    private int destPoint = 0;

    public Transform player;
    public Transform kami;
    private Vector3 distance;

    private bool canAttack;
    private float distanceFromPlayer;

    void Update()
    {
        if (!navAgent.pathPending && navAgent.remainingDistance < 0.5f)
        {
            MoveAndAttack();
        }
    }

    public override void MoveAndAttack()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        //Vector3 target = destinationPoints.transform.position;
        // navAgent.SetDestination(target);

        // Returns if no points have been set up
        if (destinationPoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        navAgent.destination = destinationPoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % destinationPoints.Length;

        distance = (kami.position - player.position);
        distance.y = 0;
        distanceFromPlayer = distance.magnitude;
        distance /= distanceFromPlayer;

        if (distanceFromPlayer < 80)
            canAttack = true;
        else
            canAttack = false;

        if (canAttack)
        {
            navAgent.destination = player.position;
        }

    }
}
