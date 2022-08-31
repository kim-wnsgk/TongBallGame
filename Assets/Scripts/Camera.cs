using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform playerTr;
    Vector3 offset;
    void Awake()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position- playerTr.position;
    }

    void LateUpdate()
    {
        transform.position = playerTr.position + offset;
    }
}
