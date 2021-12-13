using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitTeleport : MonoBehaviour
{
    //To change camera when teleported get cameraManager
    public GameObject cameraManager;

    //To print warning text
    //public Text warningText;

    /*
     * This method checks if player entered exit teleportation area
     * If player has enough keys player is teleported to old position
     * If player does not have enough keys a warning text appears
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player>().keyCount == 3)
            {
                print("exiting");
                other.gameObject.transform.position = other.GetComponent<Player>().oldPosition;
                cameraManager.GetComponent<CameraManager>().mainCamera.enabled = true;
                cameraManager.GetComponent<CameraManager>().labCamera.enabled = false;
                other.GetComponent<Player>().keyCount = 0;
            }
            else
            {
                //warningText.text = "You don't have enough keys!";
                StartCoroutine(WarningPush());
            }
        }
    }

    /*
     * A Couroutine to print warning text for 3 seconds
     */
    public IEnumerator WarningPush()
    {
        yield return new WaitForSeconds(3);
        //warningText.text = "";
    }
}
