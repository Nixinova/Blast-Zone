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
	}

}
