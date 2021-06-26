using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PauseMenu;

public class Mouse : MonoBehaviour {

	public float sensitivity = 300;
	public Transform playerBody;

	float xRot = 0;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update() {

		if (PauseMenu.inMenu) return;

		float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

		xRot -= mouseY;
		xRot = Mathf.Clamp(xRot, -90, 90);

		transform.localRotation = Quaternion.Euler(xRot, 0, 0);
		playerBody.Rotate(Vector3.up * mouseX);

	}

}
