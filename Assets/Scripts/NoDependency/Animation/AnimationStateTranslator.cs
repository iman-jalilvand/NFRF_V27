using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnimationStateTranslator : StateMachineBehaviour
{

	public bool Broadcast = false;

	public StateMessage[] OutgoingMessages;
	// OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		for (int i = 0, max = OutgoingMessages.Length; i < max; ++i) {
			if (stateInfo.IsName(OutgoingMessages[i].stateFullName)) {
				KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(animator.GetType(), animator);
				if (Broadcast) {
					Base.Call(OutgoingMessages[i].onEnter, typeof(Base), senderPair, OutgoingMessages[i].stateFullName);
				} else {
					Base.Call(OutgoingMessages[i].onEnter, animator.gameObject, senderPair, OutgoingMessages[i].stateFullName);
				}
			}
		}
	}

	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called before OnStateExit is called on any state inside this state machine
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		for (int i = 0, max = OutgoingMessages.Length; i < max; ++i) {
			if (stateInfo.IsName(OutgoingMessages[i].stateFullName)) {
				KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(animator.GetType(), animator);
				if (Broadcast) {
					Base.Call(OutgoingMessages[i].onExit, typeof(Base), senderPair, OutgoingMessages[i].stateFullName);
				} else {
					Base.Call(OutgoingMessages[i].onExit, animator.gameObject, senderPair, OutgoingMessages[i].stateFullName);
				}
			}
		}
	}
	// OnStateMove is called before OnStateMove is called on any state inside this state machine
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called before OnStateIK is called on any state inside this state machine
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
	//
	//}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
	//
	//}

	[System.Serializable]
	public struct StateMessage
	{
		public string stateFullName;
		public string onEnter;
		public string onExit;
	}
}
