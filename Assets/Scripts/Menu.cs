using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void LoadGame() {
		Debug.Log("Loading World...");
		SceneManager.LoadScene("World");
	}

	void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
			Debug.Log("Loading Menu...");
			SceneManager.LoadScene("Menu");
		}
    }

}
