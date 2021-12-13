using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : Mechanics
{
    private Animator animator; //Holds Animator of gameObject
    public int waitTime = 30; //Clouded time length
    
    //Gets animator of gameObject
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    //Starts cloud animation when called and starts coroutine
    public override void Mechanic()
    {
        animator.SetBool("blind", true);
        StartCoroutine(Cloudy(waitTime));
    }

    //A coroutine for clouded time
    public IEnumerator Cloudy(int _waitTime)

    {
        yield return new WaitForSeconds(_waitTime);

        animator.SetBool("blind", false);
    }
}
