using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpositionTrigger : MonoBehaviour
{
    public GameObject Exposition;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        Exposition.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        Exposition.SetActive(false);
    }
}
    