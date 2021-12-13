using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    //Enum for flow direction of water
    public enum flowDirection
    {
        fwd,
        bwd,
        left,
        right
    }

    public flowDirection currentDirection; //Current flow direction

    //Checks triggers
    private void OnTriggerEnter(Collider other)
    {
        /*
         * When a mount object enters the area sets its movement direction 
         * with respect to declared direction in currentDirection variable
         */
        if (other.CompareTag("Mount"))
        {
            switch (currentDirection)
            {
                case flowDirection.fwd:
                    print("fwd");
                    other.gameObject.GetComponent<Raft>().moveDirection = Vector3.forward;
                    break;
                case flowDirection.bwd:
                    print("bwd");
                    other.gameObject.GetComponent<Raft>().moveDirection = Vector3.back;
                    break;
                case flowDirection.left:
                    print("left");
                    other.gameObject.GetComponent<Raft>().moveDirection = Vector3.left;
                    break;
                case flowDirection.right:
                    print("right");
                    other.gameObject.GetComponent<Raft>().moveDirection = Vector3.right;
                    break;
                default:
                    break;
            }
        }
    }
}
