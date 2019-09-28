//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nCameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
            // LateUpdate will keep up with player every frame
            void LateUpdate()
    {
        if (player != null)
            transform.position = player.transform.position + offset;
    }
}
