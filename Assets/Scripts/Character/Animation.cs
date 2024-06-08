using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Vector3 _rotate;

    private void Update()
    {
        _character.transform.rotation = _character.Mover.DirectionMove > 0 ? Quaternion.identity : Quaternion.Euler(_rotate);
        _character.GetAnimator().SetBool(AnimatorData.Params.IsJump, _character.Mover.SurfaceType != SurfaceType.Ground);
        _character.GetAnimator().SetBool(AnimatorData.Params.IsMove, _character.Mover.IsStanding == false);
    }
}
