using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private PlayerMovement movement;

    void Awake() => animator = GetComponent<Animator>();

    void Update() => animator.SetBool("Walking", movement.IsWalking());
}
