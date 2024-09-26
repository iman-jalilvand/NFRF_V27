using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : Base
{
	[UnityEngine.Serialization.FormerlySerializedAs("callLoad")]
	public string CallLoad;
	[UnityEngine.Serialization.FormerlySerializedAs("callUnload")]
	public string CallUnload;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetActiveScene")]
	public string CallSetActiveScene;
	[UnityEngine.Serialization.FormerlySerializedAs("sceneToUnload")]
	private string SceneToUnload;
	[UnityEngine.Serialization.FormerlySerializedAs("additive")]
	public bool Additive = true;
	public bool preventDuplicate = true;

	public void Awake()
	{
		CacheMethod(CallLoad, Load);
		CacheMethod(CallUnload, Unload);
		CacheMethod(CallSetActiveScene, SetActiveScene);
	}

	public void Load(string param)
	{
		SceneManager.LoadScene(param, LoadSceneMode.Single);
    }


	private void Load(object str)
	{
		if (str is string)
		{
			SceneManager.LoadScene((string)str, LoadSceneMode.Single);
		}
	}

	private void Unload(object str)
	{
		if (str is string)
		{
			if (SceneManager.GetSceneByName((string)str).isLoaded)
			{
				SceneToUnload = (string)str;
				Invoke("Unload", 0);
			}
		}
	}

	private void Unload()
	{
		SceneManager.UnloadSceneAsync(SceneToUnload);
	}

	private void SetActiveScene(object str)
	{
		if (str is string)
		{
			Scene scene = SceneManager.GetSceneByName((string)str);
			if (scene.IsValid() && scene.isLoaded)
			{
				SceneManager.SetActiveScene(scene);
			}
		}
	}
}