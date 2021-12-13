using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Mechanics mechanicObject; //Mechanic called when button is used

    /*
     * Method called when button is pressed
     * Calls the Mechanic() method of connected object's Mechanic() class
     */
    public void OnButtonPressed()
    {
        gameObject.GetComponent<AudioSource>().Play();
        mechanicObject.Mechanic();
    }
}
