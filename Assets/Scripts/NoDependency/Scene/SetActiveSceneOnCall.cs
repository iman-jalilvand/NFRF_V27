using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SetActiveSceneOnCall : Base {
	public string Incoming;
	
	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Scene currentScene = gameObject.scene;
			UnityEngine.SceneManagement.SceneManager.SetActiveScene(currentScene);
		});
	}
	
}
