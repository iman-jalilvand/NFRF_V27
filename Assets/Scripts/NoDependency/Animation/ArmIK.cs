using UnityEngine;
using System.Collections;

public class ArmIK : MonoBehaviour
{
    public Transform LeftHand;
    public Transform RightHand;
    public Transform LeftElbow;
    public Transform RightElbow;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        if (animator != null) {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
            animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);

            if (LeftHand != null) {
                animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHand.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHand.rotation);
            }
            if (RightHand != null) {
                animator.SetIKPosition(AvatarIKGoal.RightHand, RightHand.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, RightHand.rotation);
            }
            if (LeftElbow != null) {
                animator.SetIKHintPosition(AvatarIKHint.LeftElbow, LeftElbow.position);
            }
            if (RightElbow != null) {
                animator.SetIKHintPosition(AvatarIKHint.RightElbow, RightElbow.position);
            }
        }
    }
}
