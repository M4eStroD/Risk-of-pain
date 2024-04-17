using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Vector3 _rotate;

    private void Update()
    {
        RotateToMove();
        _character.GetAnimator().SetBool(AnimatorData.Params.IsMove, _character.Mover.IsStanding == false);
        _character.GetAnimator().SetBool(AnimatorData.Params.IsJump, _character.Mover.SurfaceType != SurfaceType.Ground);
    }

    private void RotateToMove()
    {
        if (_character.Mover.DirectionMove > 0)
            _character.transform.rotation = Quaternion.identity;
        else
            _character.transform.rotation = Quaternion.Euler(_rotate);
    }
}
