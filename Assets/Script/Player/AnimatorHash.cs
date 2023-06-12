using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHash : MonoBehaviour
{
    public static readonly int speed = Animator.StringToHash("speed");
    public static readonly int isjump = Animator.StringToHash("isjump");
    public static readonly int isfall = Animator.StringToHash("isfall");
    public static readonly int hit = Animator.StringToHash("hit");
    public static readonly int dead = Animator.StringToHash("dead");

}
