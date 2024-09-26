using UnityEngine;
using System.Collections;

public class PlayLegacyAnimationOnCall : Base {
	public Animation anim;
	public string animationName;
	public string Incoming;

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			anim.Play(animationName);
		});
	}
}
