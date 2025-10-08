using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class TriggerScriptRocket : MonoBehaviour
{
    public Spinner objectToSpin;

    public void OnTriggerEnter(Collider other)
    {
        objectToSpin.activatedRocket = true;
    }
    public void OnTriggerExit(Collider other)
    {
        objectToSpin.activatedRocket = false;
    }
}

