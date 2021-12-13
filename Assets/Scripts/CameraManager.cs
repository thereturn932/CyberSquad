using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera; //Holds Main Camera
    public Camera labCamera; //Holds labirinth Camea


    //Starts main camera and disables lab camera at start
    void Start()
    {
        mainCamera.enabled = true;
        labCamera.enabled = false;
    }
}
