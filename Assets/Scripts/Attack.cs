using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public float forceHorizontal = 10;
    public float forceVertical = 5;
    public float timerDestruction = 1;
    float forceHorizontalDefault;
    void Start () {
        forceHorizontalDefault = forceHorizontal;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Acertou");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().enabled = false;
            BoxCollider2D[] boxes = collision.GetComponents<BoxCollider2D>();
            foreach(BoxCollider2D box in boxes){
                box.enabled = false;
            }
            if (collision.transform.position.x < transform.position.x)
            {
                forceHorizontal *= -1;
            }
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceHorizontal, forceVertical), ForceMode2D.Impulse);
            Destroy(collision.gameObject, timerDestruction);
            forceHorizontal = forceHorizontalDefault;
        }
    }
}
