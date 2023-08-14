
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    
    [Header("Input actions")]
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction interactAction;
    private void OnEnable()
    {
        moveAction.Enable();
        interactAction.Enable();
    }

    public void SubscribeToInteractEvent(System.Action action)
    {
        interactAction.performed += ctx => action();
    }

    public void UnsubscribeToInteractEvent(System.Action action)
    {
        interactAction.performed -= ctx => action();
    }

    public Vector2 GetMoveInput()
    {
        return moveAction.ReadValue<Vector2>().normalized;
    }
}
