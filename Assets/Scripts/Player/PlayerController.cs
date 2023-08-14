
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] public float walkSpeed = 3f;
    [SerializeField] public float runSpeed = 5f;

    private float currentSpeed = 0f;

    private PlayerInput playerInput { get => GetComponent<PlayerInput>(); }
    private PlayerMover playerMover { get => GetComponent<PlayerMover>(); }
    private PlayerAnimator playerAnimator { get => GetComponent<PlayerAnimator>();}

    private void Awake()
    {
        playerInput.SubscribeToInteractEvent(OnInteractInput);
        playerInput.SubscribeToStartRunEvent(OnRunStartInput);
        playerInput.SubscribeToEndRunEvent(OnRunEndInput);
        currentSpeed = walkSpeed;
    }
    
    void Update()
    {  
        CheckMoveInput(playerInput.GetMoveInput());
    }

    private void CheckMoveInput(Vector2 moveInput)
    {
        Vector2 moveVector = moveInput * currentSpeed;
        playerMover.Move(moveVector * Time.deltaTime);
        if (moveVector.magnitude > 0)
            playerAnimator.UpdateLocomotionAnimation(currentSpeed);
        else
            playerAnimator.UpdateLocomotionAnimation(0);
    }

    private void OnWalkInput()
    {
        currentSpeed = walkSpeed;
    }

    private void OnRunStartInput()
    {
        currentSpeed = runSpeed;
    }
    
    private void OnRunEndInput()
    {
        currentSpeed = walkSpeed;
    }

    private void OnInteractInput()
    {
        Debug.Log("Interact");
        GetComponent<PlayerAnimator>().PlayInteractAnimation();
    }

}
