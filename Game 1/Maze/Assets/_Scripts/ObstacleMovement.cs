//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Transform t;
    public float leftZ, rightZ;
    public float speed;

    Vector3 movement;

    void Start(){
        t = gameObject.GetComponent<Transform>();
        movement = new Vector3(0, 0 ,1); 
    }
    void Update () {
         t.position += movement * speed * Time.deltaTime;
        if(t.position.z > leftZ || t.position.z < rightZ){
            speed *= -1;

        }   
     }
}