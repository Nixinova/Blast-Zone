using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public Transform grass, dirt, stone, bedrock;

	void Start() {
		int groundLevel = 24;
		int mapSize = 32;
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
		Instantiate(block, new Vector3(x, y, z), block.rotation);
	}

}
