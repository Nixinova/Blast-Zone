using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour {

	[Serializable]
	public struct BlockData {
		public string name;
		public Transform model;
	}
	public BlockData[] blockData;
	public Transform terrain;

	public static Transform Terrain;
	public static Dictionary<string, Transform> Block = new Dictionary<string, Transform>();

	private static Dictionary<string, GameObject> placedBlocks = new Dictionary<string, GameObject>();

	void Awake() {
		Terrain = terrain;
		foreach (BlockData block in blockData) {
			Block.Add(block.name, block.model);
		}
	}

	public static void SpawnBlock(Transform block, int x, int y, int z) {
		Transform newBlock = Instantiate(block, new Vector3(x, y, z), block.rotation);
		newBlock.gameObject.layer = LayerMask.NameToLayer("Ground");
		newBlock.SetParent(Terrain);

		string coords = x + "," + y + "," + z;
		if (placedBlocks.ContainsKey(coords)) DestroyBlock(x, y, z);
		placedBlocks.Add(coords, newBlock.gameObject);
	}
	public static void SpawnBlock(Transform block, Vector3 pos) {
		SpawnBlock(block, (int)pos.x, (int)pos.y, (int)pos.z);
	}

	public static void DestroyBlock(int x, int y, int z) {
		string coords = x + "," + y + "," + z;
		if (!placedBlocks.ContainsKey(coords)) return;
		Destroy(placedBlocks[coords]);
		placedBlocks.Remove(coords);
	}
	public static void DestroyBlock(Vector3 pos) {
		DestroyBlock((int)pos.x, (int)pos.y, (int)pos.z);
	}

}
