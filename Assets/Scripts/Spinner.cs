using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    public bool activatedRocket;
    public float rotationSpeed;
    public float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activatedRocket)
        {
            transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
            transform.Translate(0, Time.deltaTime * movementSpeed, 0);
        }
    }
}