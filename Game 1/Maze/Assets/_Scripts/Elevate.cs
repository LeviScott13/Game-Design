//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    Transform t;
    Vector3 movement;

    public float upY, downY;
    private float speed;

    void Start(){
        speed = 2f;
        t = gameObject.GetComponent<Transform>();
        movement = new Vector3(0, 1 ,0); 
    }
    void Update () {
         t.position += movement * speed * Time.deltaTime;
        if(t.position.y > upY || t.position.y < downY){
            speed *= -1;
        }   
    }
}
