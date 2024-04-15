using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    [SerializeField] private Character _character;
    [SerializeField] private Animator _animator;

    [SerializeField] private Vector3 _rotate;

    private void Update()
    {
        RotateToMove();
        SetAnimationRun();
        SetAnimationJump();
    }

    private void SetAnimationJump()
    {
        if (_movement.SurfaceType == SurfaceType.Ground)
            _animator.SetBool("IsJump", false);
        else
            _animator.SetBool("IsJump", true);
    }

    private void SetAnimationRun()
    {
        if (_movement.IsStanding)
            _animator.SetBool("IsMove", false);
        else
            _animator.SetBool("IsMove", true);
    }

    private void RotateToMove()
    {
        if (_movement.DirectionMove > 0)
            _character.transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            _character.transform.rotation = Quaternion.Euler(_rotate);
    }
}
