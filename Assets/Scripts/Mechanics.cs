using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public string _name; //Name of mechanic

    /*
     * Method of mechanic
     * This class is base for all mechanics used in game
     * Button() class gets a mechanic Sub-classes of this
     * classes override function below.
     * Hence every mechanic which is sub-class of this class
     * can be set to Button()'s "mechanic" variable
     */
    public virtual void Mechanic()
    {

    }
}
