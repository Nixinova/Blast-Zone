using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	[Serializable]
	public struct Block {
		public string name;
		public Transform model;
	}
	public Block[] blockData;
	public Transform terrain;
	public int groundLevel = 12;
	public int bedrockLevel = 0;
	public int mapSize = 24;
	public int mapCorner = 0;

	private Dictionary<string, Transform> blocks = new Dictionary<string, Transform>();

	void Start() {
		// Assign blocks
		foreach (Block block in blockData) {
			blocks.Add(block.name, block.model);
		}

		// Generate map
		for (int i = mapCorner - 1; i <= mapSize; i++) {
			for (int y = bedrockLevel; y <= groundLevel + 10; y++) {
				SpawnBlock(blocks["barrier"], i, y, mapCorner - 1);
				SpawnBlock(blocks["barrier"], i, y, mapSize);
				SpawnBlock(blocks["barrier"], mapCorner - 1, y, i);
				SpawnBlock(blocks["barrier"], mapSize, y, i);
			}
		}
		for (int x = mapCorner; x < mapSize; x++) {
			for (int z = mapCorner; z < mapSize; z++) {
				SpawnBlock(blocks["grass"], x, groundLevel, z);
				SpawnBlock(blocks["dirt"], x, groundLevel - 1, z);
				SpawnBlock(blocks["dirt"], x, groundLevel - 2, z);
				for (int y = bedrockLevel + 3; y < groundLevel; y++) {
					SpawnBlock(blocks["stone"], x, groundLevel - y, z);
				}
				SpawnBlock(blocks["bedrock"], x, bedrockLevel, z);
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
