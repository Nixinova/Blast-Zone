using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Blocks;

public class PauseMenu : MonoBehaviour {

	public static bool inMenu = false;

	public GameObject mainMenu;
	public GameObject terrain;

	Canvas menuRenderer;

	void Awake() {
		menuRenderer = mainMenu.GetComponent<Canvas>();
		menuRenderer.enabled = false;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.Confined;
			menuRenderer.enabled = true;
			inMenu = true;
			terrain.SetActive(false);
		}
	}

	public void ResumeGame() {
		Cursor.lockState = CursorLockMode.Locked;
		menuRenderer.enabled = false;
		inMenu = false;
		terrain.SetActive(true);
	}

	public void QuitGame() {
		Debug.Log("Exiting");
		Application.Quit();
	}

}
