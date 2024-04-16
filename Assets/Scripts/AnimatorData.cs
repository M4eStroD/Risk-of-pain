using UnityEngine;

public static class AnimatorData
{
    public static class Params
    {
        public static readonly int IsMove = Animator.StringToHash(nameof(IsMove));
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    }
}
