using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Blocks;

public class World1 : MonoBehaviour {

	public int groundLevel = 12;
	public int bedrockLevel = 0;
	public int mapSize = 24;
	public int mapCorner = 0;

	void Start() {

		// Generate map
		for (int i = mapCorner - 1; i < mapSize; i++) {
			for (int y = bedrockLevel; y <= groundLevel + 10; y++) {
				SpawnBlock(Block.BARRIER, i, y, mapCorner - 1); // z-
				SpawnBlock(Block.BARRIER, i, y, mapSize); // z+
				if (mapCorner - 1 != i) SpawnBlock(Block.BARRIER, mapCorner - 1, y, i); // x-
				if (mapSize != i) SpawnBlock(Block.BARRIER, mapSize, y, i); // x+
			}
		}
		for (int x = mapCorner; x < mapSize; x++) {
			for (int z = mapCorner; z < mapSize; z++) {
				SpawnBlock(Block.GRASS, x, groundLevel, z);
				SpawnBlock(Block.DIRT, x, groundLevel - 1, z);
				SpawnBlock(Block.DIRT, x, groundLevel - 2, z);
				for (int y = groundLevel - 3; y > bedrockLevel; y--) {
					SpawnBlock(Block.STONE, x, y, z);
				}
				SpawnBlock(Block.BEDROCK, x, bedrockLevel, z);
			}
		}
	}

}
