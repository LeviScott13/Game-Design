//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LandShark : EnemyBase
{
    public Transform[] destinationPoints;
    public NavMeshAgent navAgent;
    public GameObject shotSpawn;
    public Transform shotLocation;
    public GameObject shot;

    private int destPoint = 0;

    public Transform player;
    public Transform landShark;
    private Vector3 distance;

    private bool canAttack;
    private float distanceFromPlayer;
    public float movementSpeed;

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

        // Returns if no points have been set up
        if (destinationPoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        navAgent.destination = destinationPoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % destinationPoints.Length;

        distance = (landShark.position - player.position);
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
            shotSpawn.SetActive(true);
            Instantiate(shot, shotLocation.position, shotLocation.rotation);
        }

    }
}