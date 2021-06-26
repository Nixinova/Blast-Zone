using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Start() {
		Cursor.lockState = CursorLockMode.Confined;
	}

	public void LoadGame() {
		Debug.Log("Loading World...");
		SceneManager.LoadScene("World");
	}

	public void QuitGame() {
		Debug.Log("Exiting");
		Application.Quit();
	}

}
