using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWrite : Base
{
	public string Cursor;

	public string CallType;
	public string CallAppend;
	public string CallFinish;

	public Text Target;

	public float Delay = 0;
	private int current;

	public bool Ongoing;

	private bool finish;

	public string desired = "";

	private void Awake()
	{
		CacheMethod(CallType, Type);
		CacheMethod(CallAppend, Append);
		StartCoroutine(TypingRoutine());
	}

	public void Type(object o)
	{
		Target.text = "";
		string content = o.ToString();
		desired = content;
	}

	public void Append(object o)
	{
		desired += o.ToString();
	}

	public IEnumerator TypingRoutine()
	{
		Debug.Log("Started");
		finish = false;
		Ongoing = true;
		while (Ongoing)
		{
			yield return new WaitUntil(() =>
			{
				return string.Compare(desired, Target.text) != 0;
			});
			char c = desired[current];
			Target.text += c;
			current++;

			if (Target.text == desired)
			{
				Broadcast("TextDisplayed", null);
			}

			if (Delay > 0)
			{
				yield return new WaitForSecondsRealtime(Delay);
			}
		}
	}

	//private IEnumerator ColorRoutine(string coloredContent, string written)
	//{
	//	int first = coloredContent.IndexOf('>') + 1;
	//	int last = coloredContent.LastIndexOf('<');
	//	string colorlessContent = coloredContent.Substring(first, last - first);

	//	string colorFirst = coloredContent.Substring(0, first);
	//	string colorLast = coloredContent.Substring(last);

	//	string coloredWritten = "";

	//	for (int i = 0, legnth = colorlessContent.Length; i < legnth; ++i)
	//	{
	//		char c = colorlessContent[i];
	//		if (i % FrameSkip == 0 && !finish)
	//		{
	//			yield return null;
	//		}
	//		coloredWritten += c;
	//		Target.text = written + colorFirst + coloredWritten + colorLast + Cursor;
	//	}
	//}
}
