//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    Transform t;
    Vector3 movement;

    public float leftX, rightX;
    private float speed;

    void Start(){
        speed = 4f;
        t = gameObject.GetComponent<Transform>();
        movement = new Vector3(1, 0 ,0); 
    }
    void Update () {
         t.position += movement * speed * Time.deltaTime;
        if(t.position.x < leftX || t.position.x > rightX){
            speed *= -1;
        }   
    }
}
