using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpositionTrigger : MonoBehaviour
{
    public GameObject Exposition;
    public void OnTriggerEnter(Collider other)
    {
        Exposition.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        Exposition.SetActive(false);
    }
}
    