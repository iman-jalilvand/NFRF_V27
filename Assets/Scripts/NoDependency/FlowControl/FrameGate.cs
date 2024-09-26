using UnityEngine;
using System.Collections;

public class FrameGate : Base {
	public int AllowedPerFrame = 1;
	public string Incoming;
	public string Outgoing;
	
	private int enterCount = 0;
	private int oldFrameCount;
	public bool Open
	{
		get {
			return enterCount < AllowedPerFrame;
		}
	}


	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			int currentFrameCount = Time.frameCount;
			if(oldFrameCount != currentFrameCount) {
				oldFrameCount = currentFrameCount;
				enterCount = 0;
			}

			if(Open) {
				enterCount++;
				Call(Outgoing, cachedGameObject, o);
			}
		});
	}
}
