using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 followOffset;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        Debug.Log("Camera start worked");
    }


    private void Update()
    {
       
        if (!playerTransform)
        {
            playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }
        transform.position = playerTransform.position + followOffset;
        
    }
    
    
}
