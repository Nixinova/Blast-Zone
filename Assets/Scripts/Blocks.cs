using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

	public static Transform Terrain;
	public static Dictionary<string, Transform> BlockModels = new Dictionary<string, Transform>();
	public static Dictionary<string, PlacedBlockData> PlacedBlocks = new Dictionary<string, PlacedBlockData>();

	[Serializable]
	public struct BlockData {
		public string name;
		public Transform model;
	}
	public struct PlacedBlockData {
		public string name;
		public GameObject gameObject;
	}
	public BlockData[] blockData;
	public Transform terrain;

	void Awake() {
		Terrain = terrain;
		foreach (BlockData block in blockData) {
			BlockModels.Add(block.name, block.model);
		}
	}

	/** Retrieve block data from a given location */
	public static PlacedBlockData GetBlockAt(int x, int y, int z) {
		string coords = x + "," + y + "," + z;
		if (!PlacedBlocks.ContainsKey(coords)) {
			return new PlacedBlockData() { name = Block.AIR, gameObject = BlockModels[Block.AIR].gameObject };
		}
		return PlacedBlocks[coords];
	}
	public static PlacedBlockData GetBlockAt(Vector3 pos) {
		return GetBlockAt((int)pos.x, (int)pos.y, (int)pos.z);
	}

	/** Spawn a block at a given location */
	public static void SpawnBlock(string block, int x, int y, int z) {
		Transform newBlock = Instantiate(BlockModels[block], new Vector3(x, y, z), BlockModels[block].rotation);
		newBlock.gameObject.layer = LayerMask.NameToLayer("Ground");
		newBlock.SetParent(Terrain);

		string coords = x + "," + y + "," + z;
		if (PlacedBlocks.ContainsKey(coords)) DestroyBlock(x, y, z);
		PlacedBlocks.Add(coords, new PlacedBlockData() { name = block, gameObject = newBlock.gameObject });
	}
	public static void SpawnBlock(string block, Vector3 pos) {
		SpawnBlock(block, (int)pos.x, (int)pos.y, (int)pos.z);
	}

	/** Destroy a block from a given location */
	public static void DestroyBlock(int x, int y, int z) {
		string coords = x + "," + y + "," + z;
		if (!PlacedBlocks.ContainsKey(coords)) return;
		Destroy(PlacedBlocks[coords].gameObject);
		PlacedBlocks.Remove(coords);
	}
	public static void DestroyBlock(Vector3 pos) {
		DestroyBlock((int)pos.x, (int)pos.y, (int)pos.z);
	}

	/** Check if a block is breakable */
	public static bool IsBreakable(string block) {
		return !(block == Block.AIR || block == Block.BEDROCK || block == Block.BARRIER);
	}

	/** Blocks */
	public class Block {
		public const string AIR = "air";
		public const string BARRIER = "barrier";
		public const string BEDROCK = "bedrock";
		public const string STONE = "stone";
		public const string DIRT = "dirt";
		public const string GRASS = "grass";
		public const string TNT = "tnt";
	}

}
