using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        GameManagerControl.gameManagerControl.UpdateHub();
	}
	public void DeadPlayer()
    {
        animator.SetTrigger("Death");
        GameManagerControl.gameManagerControl.SetLifes(-1);
        gameObject.GetComponent<KnightAttack>().enabled = false;
        gameObject.GetComponent<PlayerController>().enabled = false;
       

        
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void Reset()
    {
        if (GameManagerControl.gameManagerControl.GetLifes() >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
