using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Mechanics
{
    public bool _switch = false; //Boolean to check buttons status

    /*
     * When called switches the status of bridge
     */
    override public void Mechanic()
    {
        GetComponent<Animator>().SetBool("Open", !_switch);
        _switch = !_switch;
    }
}
