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
        if (Input.GetMouseButtonDown(LCLICK)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.distance < blockReach) {
				Debug.Log("HIT" + transform.position.x +","+ transform.position.y +","+ transform.position.z);
				int x = (int) hit.transform.position.x;
				int y = (int) hit.transform.position.y + 1;
				int z = (int) hit.transform.position.z;
				SpawnBlock(Block["stone"], x, y, z);
            }
        }
    }
}
