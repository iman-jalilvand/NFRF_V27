using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUpDown : MonoBehaviour
{

    // Set the speed of the movement
    public float speed = 1f;

    // Set the distance of the movement
    public float distance = 1f;

    // Set the initial position of the object
    private Vector3 initialPosition;

    void Start()
    {

        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {

        // Calculate the new position of the object
        Vector3 newPosition = initialPosition + new Vector3(0f, Mathf.Sin(Time.time * speed) * distance, 0f);

        // Move the object to the new position
        transform.position = newPosition;
    }
}
