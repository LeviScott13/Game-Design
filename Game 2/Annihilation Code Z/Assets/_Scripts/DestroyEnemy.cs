//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject enemyExplosion;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(enemyExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
