using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

	public static BirdScript instance;

	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

	private float forwardSpeed = 3f;
	private float bounceSpeed = 4f;

	private	bool didFlap;
	public bool isAlive;

	void Awake () {
		if (instance == null) {
			instance = this;
		}

		isAlive = true;
	}

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		if (isAlive) {
			Vector3 temp = transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			transform.position = temp;

			if (didFlap) {
				didFlap = false;
				myRigidBody.velocity = new Vector2 (0, bounceSpeed);
				anim.SetTrigger ("Flap");
			}
		}
	}

	public void FlapTheBird () {
		didFlap = true;
	}

} // BirdScript