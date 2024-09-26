using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// There are few scripts that requires input locks. 
/// InputManager handles all locking and who gets to unlock first. 
/// </summary>
public class InputManager : MonoBehaviour {
	public int CurrentAccessLevel
	{
		get {
			int accessLevel = 0;
			foreach(ListeningObject lo in Listeners) {
				accessLevel = Mathf.Max(accessLevel, lo.AccessLevel);
			}
			return accessLevel;
		}
	}

	private List<ListeningObject> Listeners = new List<ListeningObject>();

	public static InputManager Instance;

	private void Awake()
	{
		Instance = this;
	}

	public void Register(Object obj, int accessLevel)
	{
		ListeningObject lo = new ListeningObject();
		lo.obj = obj;
		lo.AccessLevel = accessLevel;
		Listeners.Add(lo);
	}

	public void UnRegister(Object obj)
	{
		Listeners.RemoveAll((listener)=> {
			return listener.obj == obj;
		});
	}

	public bool GetMouseButtonDown(int button, int accessLevel)
	{
		if(accessLevel >= CurrentAccessLevel) {
			return Input.GetMouseButtonDown(button);
		} else {
			return false;
		}
	}

	private struct ListeningObject
	{
		public Object obj;
		public int AccessLevel;
	}
}
