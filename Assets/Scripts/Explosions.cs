using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Blocks;

public class Explosions : MonoBehaviour {

	public static void Explode(Vector3 startPos) {
		for (int x = -3; x < 3; x++) for (int y = -3; y < 3; y++) for (int z = -3; z < 3; z++) {
			Vector3 curPos = startPos + new Vector3(x, y, z);
			string block = GetBlockAt(curPos).name;
			// Explode nearby TNT
			if (!(x == 0 && y == 0 && z == 0) && block == Block.TNT) {
				Explode(curPos);
			}
			// Destroy block
			if (IsBreakable(block)) {
				DestroyBlock(curPos);
			}
		}
	}

}
