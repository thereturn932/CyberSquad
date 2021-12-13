using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Mechanics
{
    public bool _switch;
    PlayerManager pm;
    public bool Accesable;
    public bool notConnected;
    public string interactCode; //door, light
    //public GameObject interactionText;

    void Start()
    {
        pm = GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (Accesable && notConnected)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //gameObject.GetComponent<AudioSource>().Play();
                switch (interactCode)
                {
                    case "door":
                        GetComponent<Animator>().SetBool("Open", _switch);
                        _switch = !_switch;
                        pm.playerAnima.Play("interact");
                        break;

                    case "light":
                        GetComponent<Light>().enabled = _switch;
                        pm.playerAnima.Play("interact");
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //interactionText.SetActive(true);
            Accesable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //interactionText.SetActive(false);
            Accesable = false;
        }
    }

    public override void Mechanic()
    {
        //gameObject.GetComponent<AudioSource>().Play();
        switch (interactCode)
        {
            case "door":
                GetComponent<Animator>().SetBool("Open", _switch);
                _switch = !_switch;
                break;

            case "light":
                GetComponent<Light>().enabled = _switch;
                break;
        }
    }
}
