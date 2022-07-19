using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
  public Animator animator;

  public void PlayAnimation()
  {
    bool currentState = animator.GetBool ("isAnimating");
    animator.SetBool("isAnimating", !currentState);
  }
 
}
