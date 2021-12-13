using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    public GameObject raftStand; //Where player stand while driving raft
    public GameObject driverPlayer; //Which character can drive the raft
    public GameObject dropPosition; //Where character will be put when chracter unmount
    public GameObject gameManager; //Hold gameManager to check currentPlayer

    public Vector3 moveDirection = Vector3.zero; //Initial move direction
    public float moveSpeed; //Movement speed of raft

    /*
     * Fixed update used for movement
     * Initial moveDirection is zero because it will stay at where it is
     * When raft put in water moveDirection will be modified by WaterFlow() class
     */
    void FixedUpdate()
    {
        gameObject.transform.Translate(moveDirection * moveSpeed); //Movement for raft
        if (moveDirection != Vector3.zero)
        {
            //Make object unmovable when put in water
            Destroy(gameObject.GetComponent<SpringJoint>());
        }
        if (gameManager.GetComponent<PlayerManager>().currentPlayer.GetComponent<Player>().cantMove)
        {
            //Teleport player to drive position
            gameManager.GetComponent<PlayerManager>().currentPlayer.transform.position = raftStand.transform.position;
        }
        
    }
}
