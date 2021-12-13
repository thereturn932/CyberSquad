using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfDestruction : MonoBehaviour
{
    public GameObject area; //Killer object
    private float startingScale = 1f; //Scale of object at start
    private float scale; //Scale will be set
    public float speedMultiplier; //Speed of killer area


    // Start is called before the first frame update
    void Start()
    {
        //Set scale of object to startingScale at start
        area.transform.localScale = new Vector3(startingScale, startingScale, 1);
        scale = startingScale;
    }

    // Update is called once per frame
    void Update()
    {
        //scale variable is decreased with every call with a calculation
        scale = scale - speedMultiplier * Time.deltaTime;

        //Scale of object is set to scale variable
        area.transform.localScale = new Vector3(scale, scale, 1);
    }
}
