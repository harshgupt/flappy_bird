using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour {

    private BoxCollider2D groundCollider;
    [SerializeField]
    private float groundHorizontalLength;
    [SerializeField]
    Vector2 groundOffset;

	// Use this for initialization
	void Start ()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < -groundHorizontalLength)
        {
            RepositionGround();
        }
	}

    private void RepositionGround()
    {
        groundOffset = new Vector2(groundHorizontalLength * 2.0f, 0);             //Front background moved to 2 spaces back
        transform.position = (Vector2)transform.position + groundOffset;           //(Vector2) is for type casting to avoid confusion with Vector3
    }
}
