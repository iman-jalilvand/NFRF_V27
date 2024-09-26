using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class LayerAnimationCompleteRatio : StateMachineBehaviour
{
    public string Outgoing;
    public float EnterValue;
    public float ExitValue;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float value = Mathf.Lerp(EnterValue, ExitValue, stateInfo.normalizedTime);
        KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(animator.GetType(), animator);
        Base.Call(Outgoing, animator.gameObject, senderPair, EnterValue);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float value = Mathf.Lerp(EnterValue, ExitValue, stateInfo.normalizedTime);
        KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(animator.GetType(), animator);
        Base.Call(Outgoing, animator.gameObject, senderPair, EnterValue);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        KeyValuePair<Type, object> senderPair = new KeyValuePair<Type, object>(animator.GetType(), animator);
        Base.Call(Outgoing, animator.gameObject, senderPair, ExitValue);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
