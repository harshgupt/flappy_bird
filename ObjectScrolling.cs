using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScrolling : MonoBehaviour {

    private Rigidbody2D groundRigidBody;

	// Use this for initialization
	void Start ()
    {
        groundRigidBody = GetComponent<Rigidbody2D>();
        groundRigidBody.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameController.instance.isGameOver == true)
        {
            groundRigidBody.velocity = Vector2.zero;
        }
	}
}
