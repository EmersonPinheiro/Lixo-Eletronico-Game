using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;


	void Start()
	{
		rb2d = GetComponent <Rigidbody2D> ();
	}

	void Update()
	{
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0, 0);
		rb2d.velocity = movement * speed;
	}
}
