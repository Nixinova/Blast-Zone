using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Blocks;

public class WorldGen : MonoBehaviour {

	public int groundLevel = 12;
	public int bedrockLevel = 0;
	public int mapSize = 24;
	public int mapCorner = 0;

	void Start() {

		// Generate map
		for (int i = mapCorner - 1; i <= mapSize; i++) {
			for (int y = bedrockLevel; y <= groundLevel + 10; y++) {
				SpawnBlock(Block["barrier"], i, y, mapCorner - 1);
				SpawnBlock(Block["barrier"], i, y, mapSize);
				SpawnBlock(Block["barrier"], mapCorner - 1, y, i);
				SpawnBlock(Block["barrier"], mapSize, y, i);
			}
		}
		for (int x = mapCorner; x < mapSize; x++) {
			for (int z = mapCorner; z < mapSize; z++) {
				SpawnBlock(Block["grass"], x, groundLevel, z);
				SpawnBlock(Block["dirt"], x, groundLevel - 1, z);
				SpawnBlock(Block["dirt"], x, groundLevel - 2, z);
				for (int y = bedrockLevel + 3; y < groundLevel; y++) {
					SpawnBlock(Block["stone"], x, groundLevel - y, z);
				}
				SpawnBlock(Block["bedrock"], x, bedrockLevel, z);
			}
		}
	}

}
