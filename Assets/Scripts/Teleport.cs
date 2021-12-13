using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Mechanics
{
    public GameObject transportedPlayer; //Character that will be teleported
    public GameObject teleportPosition; //Where chracter will be teleported
    public GameObject cameraManager; //Holds Camera Manager to switch camera when character is teleported
    public GameObject gameManager; //Holds Game Manager to save character's position before teleportation and switched

    public override void Mechanic()
    {
        //Play sound of object
        gameObject.GetComponent<AudioSource>().Play();
        //Changes current player to teleported player
        gameManager.GetComponent<PlayerManager>().currentPlayer = transportedPlayer;
        //Saves old position of character
        gameManager.GetComponent<PlayerManager>().currentPlayer.GetComponent<Player>().oldPosition = transportedPlayer.transform.position;
        //Changes camera
        cameraManager.GetComponent<CameraManager>().mainCamera.enabled = false;
        cameraManager.GetComponent<CameraManager>().labCamera.enabled = true;
        //Teleport player in labyrinth
        transportedPlayer.transform.position = teleportPosition.transform.position;
    }
}
