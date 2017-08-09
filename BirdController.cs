using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D birdRigidBody;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        birdRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                birdRigidBody.velocity = Vector2.zero;                      //To reset all vertical movement initially
                birdRigidBody.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
	}

    void OnCollisionEnter2D()
    {
        birdRigidBody.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.BirdDied();
    }
}
