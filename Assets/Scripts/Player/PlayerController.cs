﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float turnSmoothing = 15f;
	public float speedDampTime = 0.1f;
	public bool isSprinting;

	public float endurance = 10f;
	public bool exhausted = false;

	private PlayerHealth playerHealth;

	void Awake(){
		playerHealth = this.GetComponent<PlayerHealth> ();
	}

	void FixedUpdate () {
		Rigidbody playerBody = this.GetComponent<Rigidbody> ();
		if (playerHealth.isDead)
			playerBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		else{
			float horiz = Input.GetAxis ("Horizontal");
			float vert = Input.GetAxis ("Vertical");

			bool sprint = Input.GetButton ("Sprint");

			Vector3 movement = new Vector3 (horiz, 0.0f, vert);

			isSprinting = false;

			if (endurance <= 0f) {
				exhausted = true;
				endurance = 0f;
			}

			if (endurance >= 10f) {
				exhausted = false;
				endurance = 10f;
			}

			if (sprint && vert >= 0f && !exhausted) {
				isSprinting = true;
				speed = 6f;
				endurance -= .05f;
			} else {
				speed = 3f;
				endurance += .025f;
			}

			movement = Camera.main.transform.TransformDirection (movement);
			movement *= speed;

			Vector3 newVelocity = (movement - playerBody.velocity);
			Vector3 directionFix = new Vector3 (newVelocity.x, 0.0f, newVelocity.z);
			playerBody.AddForce (directionFix, ForceMode.VelocityChange);
		}
	}
}
