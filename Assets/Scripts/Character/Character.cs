using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    protected private Rigidbody2D Rigidbody;
    protected private Animator Animator;

    [SerializeField] private Mover _mover;
    public Mover Mover => _mover;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    public Animator GetAnimator()
    {
        return Animator;
    }
}
