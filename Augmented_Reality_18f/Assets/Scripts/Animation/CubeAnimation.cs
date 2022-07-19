using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimation : MonoBehaviour
{
  public Animator animator;

  public void OnMouseUpAsButton()
  {
    animator.SetBool("isAnimating", true);
  }
 
}
