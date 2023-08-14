using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void UpdateLocomotionAnimation(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    internal void PlayInteractAnimation()
    {
        animator.SetTrigger("Interact");
    }
}
