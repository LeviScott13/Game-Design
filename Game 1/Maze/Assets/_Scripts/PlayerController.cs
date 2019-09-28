//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{ 
    private Rigidbody rb;
    public Text gameOverText;
    public float speed;

    void Start(){
        gameOverText.text = "";
        rb  = GetComponent <Rigidbody>();
    }
    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }   
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            gameOverText.text = "Coin Found! You Win!";
        }
    }
}