using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Blocks;

public class Interact : MonoBehaviour {

	public float blockReach = 10;

	void Start() {
	}

	void Update() {
		const int LCLICK = 0;
		const int RCLICK = 1;
		// const int MCLICK = 2;
		if (Input.GetMouseButtonDown(LCLICK) || Input.GetMouseButtonDown(RCLICK)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit) && hit.distance < blockReach) {
				Vector3 pos = hit.transform.position;
				Vector3 face = hit.normal;
				if (Input.GetMouseButtonDown(RCLICK)) {
					Vector3 diff = gameObject.transform.position - (pos + face);
					Vector3 delta = new Vector3(Math.Abs(diff.x), Math.Abs(diff.y), Math.Abs(diff.z));
					bool isInBody = delta.x <= 1 && delta.y <= 1 && delta.z <= 1;
					Debug.Log(String.Format("delta={0}, inbody={1}", delta, isInBody));
					if (!isInBody) {
						SpawnBlock(Block["stone"], pos + face);
					}
				}
				else {
					DestroyBlock(pos);
				}
			}
		}
	}
}
