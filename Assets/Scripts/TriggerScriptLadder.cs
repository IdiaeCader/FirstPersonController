using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class TriggerScriptLadder : MonoBehaviour
{
    public PlayerMovement climbingPlayer;
    public GameObject LadderHud;

    public void OnTriggerEnter(Collider other)
    {
        climbingPlayer.isClimbing = true;
        LadderHud.SetActive(true);
        
    }
    public void OnTriggerExit(Collider other)
    {
        climbingPlayer.isClimbing = false;
        LadderHud.SetActive(false);
    }
}