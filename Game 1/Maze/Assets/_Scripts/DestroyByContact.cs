//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour
{
    Vector3 startPos = new Vector3(0.21f, 0.5f, -23.81f);
    void OnTriggerEnter(Collider col){
      if(col.tag == "Player"){
            col.gameObject.SetActive(false);
            col.gameObject.transform.position = startPos;
            col.gameObject.SetActive(true);
            col.gameObject.GetComponent<Rigidbody>().Sleep();
        }
    }
}
