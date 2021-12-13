using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public bool isActive;
    public Mechanics mechanicObject;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetTrigger("Pressed");
        ButtonFunction();
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Animator>().SetTrigger("Released");
    }

    public void ButtonFunction()
    {
        mechanicObject.Mechanic();
    }
}
