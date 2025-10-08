using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    public GameObject closedDoor;
    public GameObject openDoor;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            closedDoor.SetActive(true);
            openDoor.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
