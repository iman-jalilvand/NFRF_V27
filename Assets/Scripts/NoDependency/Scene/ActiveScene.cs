using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActiveScene : MonoBehaviour {
	void Start () {
		Scene currentScene = gameObject.scene;
		UnityEngine.SceneManagement.SceneManager.SetActiveScene(currentScene);
	}
}
