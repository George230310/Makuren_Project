using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamera : MonoBehaviour
{
    private Vector3 startLocation;
    private Vector3 endLocation;
    
    private void Start()
    {
        startLocation = gameObject.transform.position;
        endLocation = startLocation + new Vector3(13f, -1f, 0f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, endLocation, Time.deltaTime);
    }
}
