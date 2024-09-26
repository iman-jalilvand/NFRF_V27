using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// You could have this in 2 scripts, communicating with each other. 
/// Probably that's next best thing, but is that method truely better?
/// </summary>
public class ToggleParentTransform : Base {
	private Transform Saved;
	public string CallDetachParent;
    public string CallAttachParent;

	private void Awake()
	{
		CacheMethod(CallDetachParent, (o)=> {
			Scene scene = cachedGameObject.scene;
			Saved = cachedTransform.parent;
			cachedTransform.parent = null;
			SceneManager.MoveGameObjectToScene(cachedGameObject, scene);
		});
		CacheMethod(CallAttachParent, (o)=> {
			cachedTransform.parent = Saved;
			Saved = null;
		});
	}
}