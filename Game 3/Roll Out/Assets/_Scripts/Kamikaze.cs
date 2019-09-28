//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kamikaze : EnemyBase
{
    //public GameObject enemy;
    public Transform player1;
    public Transform player2;
    public float speed = 1;

    void Start()
    {
    }
    public override void MoveAndAttack()
    {
        if (this == null)
            return;

        float distance = Vector3.Distance(this.transform.position, player1.position);
        float distance2 = Vector3.Distance(this.transform.position, player2.position);
        if (distance < 5 && distance < distance2)
        { 
            Debug.Log("Tracking P1");
            //enemy = GameObject.FindGameObjectWithTag("Player");
            Vector3 delta = player1.position - this.transform.position;
            delta.Normalize();

            float moveSpeed = speed * Time.deltaTime;

            transform.position = transform.position + (delta * moveSpeed);
        }
        else if(distance2 < 5 && distance2 < distance)
        {
            Debug.Log("Tracking P2");
            //enemy = GameObject.FindGameObjectWithTag("Player2");
            Vector3 delta = player2.position - this.transform.position;
            delta.Normalize();

            float moveSpeed = speed * Time.deltaTime;

            transform.position = transform.position + (delta * moveSpeed);
        }
    }
}
