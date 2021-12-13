using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    bool Accesable;
    SpringJoint joint;
    GameObject nearestPlayer;
    public GameObject tasi;
    public GameObject birak;

    private void Start()
    {
        joint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        try
        {
                if (Accesable)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    joint.connectedBody = nearestPlayer.GetComponent<Rigidbody>();
                    //tasi.SetActive(false);
                }
            }


            if (joint.connectedBody != null)
            {
                //birak.SetActive(true);

                if (Input.GetKeyDown(KeyCode.X))
                {
                    joint.connectedBody = null;
                    //birak.SetActive(false);
                }
            }
        }
        catch (System.Exception e)
        {
            print(e);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.CompareTag("Player") && joint.connectedBody == null)
            {
                nearestPlayer = other.gameObject;
                Accesable = true;
                //tasi.SetActive(true);
            }
        }
        catch (System.Exception e)
        {
            print(e);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Accesable = false;
            nearestPlayer = null;
            //tasi.SetActive(false);
        }
    }
}
