//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    public float frequency = 1f;
    public float amplitude = 1f; 
    Vector3 startPos;
    float elapsedTime = 0f;

    void Start () {
        startPos = transform.position;
    }
    void Update () {
        elapsedTime += Time.deltaTime * Time.timeScale * frequency;
        transform.position = startPos + Vector3.up * Mathf.Sin(elapsedTime) * amplitude;
    }
}
