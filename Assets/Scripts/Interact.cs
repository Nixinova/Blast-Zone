using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Blocks;

public class Interact : MonoBehaviour {

	public float blockReach = 10;

	const int LCLICK = 0;
	const int RCLICK = 1;
	const int MCLICK = 2;

	int tick = 0;

	void Update() {
		bool mouseClicked = Input.GetMouseButtonDown(LCLICK) || Input.GetMouseButtonDown(RCLICK);
		bool mouseHeld = (Input.GetMouseButton(LCLICK) || Input.GetMouseButton(RCLICK)) && tick == 1;
		if (mouseClicked || mouseHeld) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit) && hit.distance < blockReach) {
				Vector3 pos = hit.transform.position;
				Vector3 face = hit.normal;
				if (Input.GetMouseButton(RCLICK)) {
					Vector3 diff = gameObject.transform.position - (pos + face);
					Vector3 delta = new Vector3(Math.Abs(diff.x), Math.Abs(diff.y), Math.Abs(diff.z));
					bool isInBody = delta.x <= 1 && delta.y <= 2 && delta.z <= 1;
					if (!isInBody) {
						SpawnBlock(Block["stone"], pos + face);
					}
				}
				else {
					DestroyBlock(pos);
				}
			}
		}
		tick++;
		tick %= 20;
	}
}
