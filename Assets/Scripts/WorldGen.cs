using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public Transform grass, dirt, stone, bedrock;
	public Transform terrain;

	void Start() {
		int groundLevel = 12;
		int mapSize = 24;
		for (int i = 0; i < mapSize; i++) {
			for (int j = 0; j < mapSize; j++) {
				SpawnBlock(grass, i, groundLevel, j);
				SpawnBlock(dirt, i, groundLevel - 1, j);
				SpawnBlock(dirt, i, groundLevel - 2, j);
				for (int y = 3; y < groundLevel; y++) {
					SpawnBlock(stone, i, groundLevel - y, j);
				}
				SpawnBlock(bedrock, i, 0, j);
			}
		}
    }

	void Update() {
    }

	void SpawnBlock(Transform block, float x, float y, float z) {
		Transform newBlock = Instantiate(block, new Vector3(x, y, z), block.rotation);
		newBlock.gameObject.layer = LayerMask.NameToLayer("Ground");
		newBlock.SetParent(terrain);
	}

}
