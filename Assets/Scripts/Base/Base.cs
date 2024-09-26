using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using UnityEngine.Profiling;

public class Base : MonoBehaviour
{
	public int priority;
	public int moduleLevel = 1;
	/// <summary>
	/// If true, cachedGameObject is parent instead. 
	/// </summary>
	public bool module = false;

	public Transform CachedTransform
	{
		get
		{
			if (cachedTransform == null)
			{
				UpdateCachedFields();
			}
			return cachedTransform;
		}
	}

	protected GameObject cachedGameObject;
	protected Transform cachedTransform;

	protected GameObject cachedOriginGameObject;
	protected Transform cachedOriginTransform;

	private Type cachedType;

	public delegate void SingleParamMethod(object o);

	public static Type CachedBaseType = typeof(Base);

	/// <summary>
	/// Holds all methods registered with this instance.
	/// It could be listening on different gameObject, 
	/// but when this object is enabled/disabled, 
	/// CachedMethods will be used to subscribe to the correct gameobjects.
	/// </summary>
	protected Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = new Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>>();

	/// <summary>
	/// Dictionary being used to hold reference of what type 
	/// is linked with what script and what method names.
	/// 
	/// TypeToBase can be used to track down every scripts registered under a type,
	/// GameObjectToBase can be used to track down every scripts registered under a gameobject,
	/// NameToBase can be used to track down every scripts registered under a name.
	/// 
	/// Each dictionary contains another dictionary, that can be used to
	/// track down an object with method name, or key.
	/// Using that dictionary and method name, actual method can be found.
	/// </summary>
	protected static Dictionary<Type, Dictionary<string, HashSet<Base>>> TypeToBase = new Dictionary<Type, Dictionary<string, HashSet<Base>>>();
	protected static Dictionary<GameObject, Dictionary<string, HashSet<Base>>> GameObjectToBase = new Dictionary<GameObject, Dictionary<string, HashSet<Base>>>();

	protected static Stack<KeyValuePair<Type, object>> CallStack = new Stack<KeyValuePair<Type, object>>();

	//private Dictionary<Type, HashSet<Base>> TypeToBaseNodes = new Dictionary<Type, HashSet<Base>>();
	//	private Dictionary<GameObject, HashSet<Base>> GameObjectToBaseNode = new Dictionary<GameObject, HashSet<Base>>();

	public Base()
		: base()
	{
		cachedType = GetType();
	}

	/// <summary>
	/// Caches a method to listen to a message.
	/// </summary>
	/// <param name="msg">message to listen to</param>
	/// <param name="spm">method with single object parameter</param>
	/// <param name="under">gameobject to listen to. If null cachedGameObject will be used</param>
	protected void CacheMethod(string msg, SingleParamMethod spm, GameObject under = null)
	{
		UpdateCachedFields();
		if (under == null)
		{
			under = cachedGameObject;
		}

		if (spm != null && msg != null)
		{
			CachedMethods[msg] = new KeyValuePair<GameObject, SingleParamMethod>(under, spm);
		}
		if (enabled)
		{
			Subscribe(msg, under);
		}
	}

	protected void UncacheMethodCacheMethod(string msg, GameObject under = null)
	{
		UpdateCachedFields();
		if (under == null)
		{
			under = cachedGameObject;
		}
		if (CachedMethods.ContainsKey(msg))
		{
			CachedMethods.Remove(msg);
		}

		Unsubscribe(msg, under);
	}

	protected virtual void OnEnable()
	{
		UpdateCachedFields();
		foreach (KeyValuePair<string, KeyValuePair<GameObject, SingleParamMethod>> pair in CachedMethods)
		{
			string message = pair.Key;
			GameObject under = pair.Value.Key;
			Subscribe(message, under);
		}
	}

	protected virtual void OnDisable()
	{
		foreach (KeyValuePair<string, KeyValuePair<GameObject, SingleParamMethod>> pair in CachedMethods)
		{
			string message = pair.Key;
			GameObject under = pair.Value.Key;
			Unsubscribe(message, under);
		}
	}

	protected virtual void Subscribe(string message, GameObject under = null)
	{
		UpdateCachedFields();
		Type t = cachedType;
		while (t.IsSubclassOf(CachedBaseType) || t.Equals(CachedBaseType))
		{
			Register(TypeToBase, t, message, this);
			t = t.BaseType;
		}
		if (under == null)
		{
			under = cachedGameObject;
		}

		Register(GameObjectToBase, under, message, this);
	}

	protected virtual void Unsubscribe(string message, GameObject under)
	{
		Type t = cachedType;
		while (t.IsSubclassOf(CachedBaseType) || t.Equals(CachedBaseType))
		{
			UnRegister(TypeToBase, t, message);
			t = t.BaseType;
		}

		UnRegister(GameObjectToBase, under, message);
	}

	public void Broadcast(string method, object o)
	{
		Call(method, typeof(Base), o);
	}

	public void Call(string method, GameObject go)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, go, senderPair);
	}

	public void Call(string method, GameObject go, object o)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, go, senderPair, o);
	}

	public void Call(string method, GameObject go, int o)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, go, senderPair, o);
	}

	public void Call(string method, GameObject go, float o)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, go, senderPair, o);
	}

	public void Call(string method, GameObject go, bool o)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, go, senderPair, o);
	}

	public void Call(string method, GameObject go, Transform o)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, go, senderPair, o);
	}

	public void Call(string method, GameObject go, GameObject o)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, go, senderPair, o);
	}

	public void Call(string method, Type t, object o = null)
	{
		KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(this.GetType(), this);
		Call(method, t, senderPair, o);
	}

	public static void Call(string method, Type t, KeyValuePair<Type, object> senderPair, object o = null)
	{
		CallStack.Push(senderPair);
		Call(method, TypeToBase, t, o);
		CallStack.Pop();
	}

	public static void Call(string method, GameObject go, KeyValuePair<Type, object> senderPair, object o)
	{
		CallStack.Push(senderPair);
		Call(method, GameObjectToBase, go, o);
		CallStack.Pop();
	}

	public static void Call(string method, GameObject go, KeyValuePair<Type, object> senderPair)
	{
		CallStack.Push(senderPair);
		Call(method, GameObjectToBase, go);
		CallStack.Pop();
	}

	public static void Call(string method, GameObject go, KeyValuePair<Type, object> senderPair, Transform o)
	{
		CallStack.Push(senderPair);
		Call(method, GameObjectToBase, go, o);
		CallStack.Pop();
	}

	public static void Call(string method, GameObject go, KeyValuePair<Type, object> senderPair, GameObject o)
	{
		CallStack.Push(senderPair);
		Call(method, GameObjectToBase, go, o);
		CallStack.Pop();
	}

	public static void Call(string method, GameObject go, KeyValuePair<Type, object> senderPair, float o)
	{
		CallStack.Push(senderPair);
		Call(method, GameObjectToBase, go, o);
		CallStack.Pop();
	}

	public static void Call(string method, GameObject go, KeyValuePair<Type, object> senderPair, int o)
	{
		CallStack.Push(senderPair);
		Call(method, GameObjectToBase, go, o);
		CallStack.Pop();
	}

	public static void Call(string method, GameObject go, KeyValuePair<Type, object> senderPair, bool o)
	{
		CallStack.Push(senderPair);
		Call(method, GameObjectToBase, go, o);
		CallStack.Pop();
	}

	private static void Call(string method, Dictionary<Type, Dictionary<string, HashSet<Base>>> dic, Type key, object o)
	{
		if (string.IsNullOrEmpty(method))
		{
			return;
		}

		if (key == null || !dic.ContainsKey(key) || !dic[key].ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = dic[key][method];
		// need sortedset from .Net 4 or make one myself to optimize this...
		List<Base> sl = new List<Base>(node);

		sl.Sort((a, b) =>
		{
			// descending. Tried just using -, but profiler says its more expansive. Why???
			return b.priority - a.priority;
		});

		foreach (Base current in sl)
		{
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			if (CachedMethods.ContainsKey(method))
			{
				CachedMethods[method].Value(o);
			}
		}
	}

	private static Queue<Base[]> slaq = new Queue<Base[]>();

	private static BaseComparer comparer = new BaseComparer();

	private class BaseComparer : IComparer<Base>
	{
		public int Compare(Base a, Base b)
		{
			return b.priority - a.priority;
		}
	}

	private static void Call(string method, Dictionary<GameObject, Dictionary<string, HashSet<Base>>> dic, GameObject key, object o)
	{
		Dictionary<string, HashSet<Base>> nodeDictionary;
		if (string.IsNullOrEmpty(method) || key == null || !dic.ContainsKey(key) || !(nodeDictionary = dic[key]).ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = nodeDictionary[method];
		int length = node.Count;
		Base[] sla;// = new Base[node.Count];
		if (slaq.Count > 0)
		{
			sla = slaq.Dequeue();
			if (sla.Length < length)
			{
				Array.Resize(ref sla, length);
			}
		}
		else
		{
			sla = new Base[node.Count];
		}

		node.CopyTo(sla, 0, length);
		Array.Sort(sla, 0, length, comparer);

		for (int i = 0; i < length; ++i)
		{
			Base current = sla[i];
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			KeyValuePair<GameObject, SingleParamMethod> methodPair;
			if (CachedMethods.ContainsKey(method) && key == (methodPair = CachedMethods[method]).Key)
			{
				methodPair.Value(o);
			}
		}

		slaq.Enqueue(sla);
	}

	private static void Call(string method, Dictionary<GameObject, Dictionary<string, HashSet<Base>>> dic, GameObject key)
	{
		Dictionary<string, HashSet<Base>> nodeDictionary;
		if (string.IsNullOrEmpty(method) || key == null || !dic.ContainsKey(key) || !(nodeDictionary = dic[key]).ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = nodeDictionary[method];
		int length = node.Count;
		Base[] sla;// = new Base[node.Count];
		if (slaq.Count > 0)
		{
			sla = slaq.Dequeue();
			if (sla.Length < length)
			{
				Array.Resize(ref sla, length);
			}
		}
		else
		{
			sla = new Base[node.Count];
		}

		node.CopyTo(sla, 0, length);
		Array.Sort(sla, 0, length, comparer);

		for (int i = 0; i < length; ++i)
		{
			Base current = sla[i];
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			KeyValuePair<GameObject, SingleParamMethod> methodPair;
			if (CachedMethods.ContainsKey(method) && key == (methodPair = CachedMethods[method]).Key)
			{
				methodPair.Value(null);
			}
		}

		slaq.Enqueue(sla);
	}

	private static void Call(string method, Dictionary<GameObject, Dictionary<string, HashSet<Base>>> dic, GameObject key, float o)
	{
		Dictionary<string, HashSet<Base>> nodeDictionary;
		if (string.IsNullOrEmpty(method) || key == null || !dic.ContainsKey(key) || !(nodeDictionary = dic[key]).ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = nodeDictionary[method];
		int length = node.Count;
		Base[] sla;// = new Base[node.Count];
		if (slaq.Count > 0)
		{
			sla = slaq.Dequeue();
			if (sla.Length < length)
			{
				Array.Resize(ref sla, length);
			}
		}
		else
		{
			sla = new Base[node.Count];
		}

		node.CopyTo(sla, 0, length);
		Array.Sort(sla, 0, length, comparer);

		for (int i = 0; i < length; ++i)
		{
			Base current = sla[i];
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			KeyValuePair<GameObject, SingleParamMethod> methodPair;
			if (CachedMethods.ContainsKey(method) && key == (methodPair = CachedMethods[method]).Key)
			{
				methodPair.Value(o);
			}
		}

		slaq.Enqueue(sla);
	}

	private static void Call(string method, Dictionary<GameObject, Dictionary<string, HashSet<Base>>> dic, GameObject key, int o)
	{
		Dictionary<string, HashSet<Base>> nodeDictionary;
		if (string.IsNullOrEmpty(method) || key == null || !dic.ContainsKey(key) || !(nodeDictionary = dic[key]).ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = nodeDictionary[method];
		int length = node.Count;
		Base[] sla;// = new Base[node.Count];
		if (slaq.Count > 0)
		{
			sla = slaq.Dequeue();
			if (sla.Length < length)
			{
				Array.Resize(ref sla, length);
			}
		}
		else
		{
			sla = new Base[node.Count];
		}

		node.CopyTo(sla, 0, length);
		Array.Sort(sla, 0, length, comparer);

		for (int i = 0; i < length; ++i)
		{
			Base current = sla[i];
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			KeyValuePair<GameObject, SingleParamMethod> methodPair;
			if (CachedMethods.ContainsKey(method) && key == (methodPair = CachedMethods[method]).Key)
			{
				methodPair.Value(o);
			}
		}

		slaq.Enqueue(sla);
	}

	private static void Call(string method, Dictionary<GameObject, Dictionary<string, HashSet<Base>>> dic, GameObject key, bool o)
	{
		Dictionary<string, HashSet<Base>> nodeDictionary;
		if (string.IsNullOrEmpty(method) || key == null || !dic.ContainsKey(key) || !(nodeDictionary = dic[key]).ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = nodeDictionary[method];
		int length = node.Count;
		Base[] sla;// = new Base[node.Count];
		if (slaq.Count > 0)
		{
			sla = slaq.Dequeue();
			if (sla.Length < length)
			{
				Array.Resize(ref sla, length);
			}
		}
		else
		{
			sla = new Base[node.Count];
		}

		node.CopyTo(sla, 0, length);
		Array.Sort(sla, 0, length, comparer);

		for (int i = 0; i < length; ++i)
		{
			Base current = sla[i];
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			KeyValuePair<GameObject, SingleParamMethod> methodPair;
			if (CachedMethods.ContainsKey(method) && key == (methodPair = CachedMethods[method]).Key)
			{
				methodPair.Value(o);
			}
		}

		slaq.Enqueue(sla);
	}


	private static void Call(string method, Dictionary<GameObject, Dictionary<string, HashSet<Base>>> dic, GameObject key, Transform o)
	{
		Dictionary<string, HashSet<Base>> nodeDictionary;
		if (string.IsNullOrEmpty(method) || key == null || !dic.ContainsKey(key) || !(nodeDictionary = dic[key]).ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = nodeDictionary[method];
		int length = node.Count;
		Base[] sla;// = new Base[node.Count];
		if (slaq.Count > 0)
		{
			sla = slaq.Dequeue();
			if (sla.Length < length)
			{
				Array.Resize(ref sla, length);
			}
		}
		else
		{
			sla = new Base[node.Count];
		}

		node.CopyTo(sla, 0, length);
		Array.Sort(sla, 0, length, comparer);

		for (int i = 0; i < length; ++i)
		{
			Base current = sla[i];
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			KeyValuePair<GameObject, SingleParamMethod> methodPair;
			if (CachedMethods.ContainsKey(method) && key == (methodPair = CachedMethods[method]).Key)
			{
				methodPair.Value(o);
			}
		}

		slaq.Enqueue(sla);
	}

	private static void Call(string method, Dictionary<GameObject, Dictionary<string, HashSet<Base>>> dic, GameObject key, GameObject o)
	{
		Dictionary<string, HashSet<Base>> nodeDictionary;
		if (string.IsNullOrEmpty(method) || key == null || !dic.ContainsKey(key) || !(nodeDictionary = dic[key]).ContainsKey(method))
		{
			return;
		}

		HashSet<Base> node = nodeDictionary[method];
		int length = node.Count;
		Base[] sla;// = new Base[node.Count];
		if (slaq.Count > 0)
		{
			sla = slaq.Dequeue();
			if (sla.Length < length)
			{
				Array.Resize(ref sla, length);
			}
		}
		else
		{
			sla = new Base[node.Count];
		}

		node.CopyTo(sla, 0, length);
		Array.Sort(sla, 0, length, comparer);

		for (int i = 0; i < length; ++i)
		{
			Base current = sla[i];
			// cachedmethods contains all scripts that were "with" that base object.
			Dictionary<string, KeyValuePair<GameObject, SingleParamMethod>> CachedMethods = current.CachedMethods;
			KeyValuePair<GameObject, SingleParamMethod> methodPair;
			if (CachedMethods.ContainsKey(method) && key == (methodPair = CachedMethods[method]).Key)
			{
				methodPair.Value(o);
			}
		}

		slaq.Enqueue(sla);
	}

	private void Register<T>(Dictionary<T, Dictionary<string, HashSet<Base>>> dictionary, T key, string message, Base value)
	{
		HashSet<Base> baseNode;
		bool hasKey = dictionary.ContainsKey(key);
		bool hasMessage = hasKey && dictionary[key].ContainsKey(message);

		if (hasMessage)
		{
			baseNode = dictionary[key][message];
		}
		else
		{
			if (!hasKey)
			{
				dictionary[key] = new Dictionary<string, HashSet<Base>>();
			}
			baseNode = new HashSet<Base>();
			dictionary[key][message] = baseNode;
		}

		baseNode.Add(value);
	}

	private void UnRegister<T>(Dictionary<T, Dictionary<string, HashSet<Base>>> dictionary, T key, string message)
	{
		if (dictionary.ContainsKey(key) == false || dictionary[key].ContainsKey(message) == false)
		{
			return;
		}

		dictionary[key][message].Remove(this);

		if (dictionary[key][message] == null || dictionary[key][message].Count == 0)
		{
			dictionary[key].Remove(message);
		}

		if (dictionary[key] == null || dictionary[key].Count == 0)
		{
			dictionary.Remove(key);
		}
	}

	protected void UpdateCachedFields()
	{
		cachedOriginGameObject = gameObject;
		cachedOriginTransform = transform;

		Transform actualTransform = cachedOriginTransform;
		int lv = moduleLevel;
		while (module && lv-- > 0)
		{
			actualTransform = actualTransform.parent;
			if (actualTransform == null)
			{
				throw new UnityException("Module Level must be smaller than number of ancestors for " + cachedOriginTransform.name);
			}
		}

		cachedTransform = actualTransform;
		cachedGameObject = actualTransform.gameObject;
	}

	protected GameObject GetCachedGameObject(Base b)
	{
		return b.cachedGameObject;
	}
}
