using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Blocks;
using static Explosions;

public class Interact : MonoBehaviour {

	public float blockReach = 10;

	const int LCLICK = 0;
	const int RCLICK = 1;
	const int MCLICK = 2;

	int tick = 0;

	void Update() {
		tick++;
		tick %= 20;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);

		bool targetedBlock = hit.distance < blockReach;
		bool inSelf = hit.distance == 0;
		if (!targetedBlock || inSelf) return;

		Vector3 pos = hit.transform.position;
		Vector3 face = hit.normal;
		string block = GetBlockAt(pos).name;

		// Right click
		if (Input.GetMouseButtonDown(RCLICK)) {
			Vector3 diff = gameObject.transform.position - (pos + face);
			Vector3 delta = new Vector3(Math.Abs(diff.x), Math.Abs(diff.y), Math.Abs(diff.z));
			bool isInBody = delta.x <= 1 && delta.y <= 2 && delta.z <= 1;
			if (!isInBody) {
				SpawnBlock(Block.TNT, pos + face);
			}
		}

		// Left click
		if (Input.GetMouseButtonDown(LCLICK)) {
			if (IsBreakable(block)) {
				DestroyBlock(pos);
			}
		}

		// Interact
		if (Input.GetKeyDown(KeyCode.E)) {
			if (block == Block.TNT) {
				Explosions.Explode(pos);
			}
		}

		// Look
		Text hoverText = GameObject.Find("HoverText").GetComponent<Text>();
		if (block == Block.TNT) {
			hoverText.text = "Press E to blow up";
		}
		else {
			hoverText.text = "";
		}

	}

}
