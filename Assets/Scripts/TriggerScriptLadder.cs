using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class TriggerScriptLadder : MonoBehaviour
{
    public PlayerMovement climbingPlayer;

    public void OnTriggerEnter(Collider other)
    {
        climbingPlayer.isClimbing = true;
    }
    public void OnTriggerExit(Collider other)
    {
        climbingPlayer.isClimbing = false;
    }
}
