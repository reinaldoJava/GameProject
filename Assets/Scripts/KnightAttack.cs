using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnightAttack : MonoBehaviour {
    private Animator animator;
    public float intervalAttack;
    private float nextAttack;

	void Start () {
        animator = gameObject.GetComponent<Animator>();
        GameManagerControl.gameManagerControl.UpdateHub();

    }
	
	void Update () {
		if(Input.GetButtonDown("Fire1") && Time.time > nextAttack)
        {
            attacking();
        } 
	}

    private void attacking()
    {
        animator.SetTrigger("Attack");
        nextAttack = Time.time + intervalAttack;
    }
   
}
