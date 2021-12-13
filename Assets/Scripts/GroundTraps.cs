using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTraps : Mechanics
{
    public float ascendSpeed; //Ascend speed of ground traps
    public float finalHeight; //Final Height of trap
    private bool isActivated; //True when active

    /*
     * Overrides the Mechanic() method of Mechanics() class
     * Called by Button() class
     */
    public override void Mechanic()
    {
        isActivated = true;
    }

    //Increases y-position of trap every second until finalHeight value is reached
    public void FixedUpdate()
    {
        //Checks if trap is activated
        if (isActivated)
        {
            //Increase y-position
            if (gameObject.transform.position.y < finalHeight)
            {
                gameObject.transform.Translate(new Vector3(0,0,1) * ascendSpeed);
            }
        }
    }
}
