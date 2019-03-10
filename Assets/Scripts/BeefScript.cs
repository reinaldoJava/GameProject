using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefScript : MonoBehaviour {
    Animator animator;
    CircleCollider2D circleCollider2D;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D outher)
    {
        if (outher.gameObject.CompareTag("Player"))
        {
            GameManagerControl.gameManagerControl.SetBeef(1);
            circleCollider2D.enabled = false;
            animator.SetTrigger("Collect");
            Destroy(gameObject, 0667f);
        }
    }
}
