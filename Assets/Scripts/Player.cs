using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Gameplay checks required for some actions
    public bool inFinishCollider; //True if character enters ending area
    public bool isKilled; //True if character is killed
    public bool isPressible;
    public GameObject interactedObject;
    public Vector3 oldPosition;
    public int keyCount;
    public bool isMountable;
    public bool cantMove;
    public GameObject gameManager;

    //public GameObject interactionText;
    //public GameObject mountText;

    [SerializeField]
    private AudioClip[] footstepSounds;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
            this.inFinishCollider = true;

        if (other.CompareTag("Killer"))
        {
            this.isKilled = true;
        }

        if (other.CompareTag("Button"))
        {
            if (other.CompareTag("Button"))
            {
                //interactionText.SetActive(true);
                isPressible = true;
                interactedObject = other.gameObject;
            }
        }

        if (other.CompareTag("Key"))
        {
            keyCount++;
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Mount") && other.gameObject.GetComponent<Raft>().driverPlayer == gameObject)
        {
            //mountText.SetActive(true);
            print("a");
            isMountable = true;
            interactedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Button"))
        {
            //interactionText.SetActive(false);
            interactedObject = null;
            isPressible = false;
        }

        if (other.CompareTag("Mount"))
        {
            //mountText.SetActive(false);
            isMountable = false;
            interactedObject = null;
        }
    }


    private void OnTriggerStay(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            this.isKilled = true;
        }
    }

    public void Step()
    {
        audioSource.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.Play();
    }
}
