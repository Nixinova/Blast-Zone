using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public CharacterController controller;

	public float speed = 6;
	public float gravity = -30;
	public float jumpHeight = 1;

	public Transform groundChecker;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

	void Start() {
	}

	void Update() {

		// Horizontal movement

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 movement = transform.right * x + transform.forward * z;
		controller.Move(movement * speed * Time.deltaTime);

		// Vertical movement

		isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);
		if (isGrounded) {
			if (velocity.y < 0) {
				velocity.y = -1f;
			}
			if (Input.GetButton("Jump")) {
				velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2);
			}
		}

		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

	}

}
