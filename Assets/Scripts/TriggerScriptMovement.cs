using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriggerScriptMovement : MonoBehaviour
{

    public bool activated;

    public Transform objectToMove;
    public Transform openDestination;
    public Transform closedDestination;

    public float speed;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activated = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activated = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, openDestination.position, Time.deltaTime * speed);
        }
        if (activated == false)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, closedDestination.position, Time.deltaTime * speed);
        }
    }
}
