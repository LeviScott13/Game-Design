//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour
{
    public GameObject enemyExplosion;
    Vector3 startPos = new Vector3(0.834f, 0.7f, -0.035f);
    void OnTriggerEnter(Collider col){
        if(col.tag == "Player" || col.tag == "Player2")
        {
            Instantiate(enemyExplosion, col.transform.position, col.transform.rotation);
            col.gameObject.SetActive(false);
            col.gameObject.transform.position = startPos;
            col.gameObject.SetActive(true);
            col.gameObject.GetComponent<Rigidbody>().Sleep();
        }
    }
}
