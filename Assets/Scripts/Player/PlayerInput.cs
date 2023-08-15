
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    
    [Header("Input actions")]
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction interactAction;
    [SerializeField] private InputAction startRunAction;
    [SerializeField] private InputAction endRunAction;
    [SerializeField] private InputAction toggleInventoryAction;

    private void OnEnable()
    {
        moveAction.Enable();
        interactAction.Enable();
        startRunAction.Enable();
        endRunAction.Enable();
        toggleInventoryAction.Enable();
    }

//Event handled actions
    //Interact
    public void SubscribeToInteractEvent(System.Action action)
    {
        interactAction.performed += ctx => action();
    }

    public void UnsubscribeToInteractEvent(System.Action action)
    {
        interactAction.performed -= ctx => action();
    }
    //Start run
    public void SubscribeToStartRunEvent(System.Action action)
    {
        startRunAction.performed += ctx => action();
    }
    public void UnsubscribeToStartRunEvent(System.Action action)
    {
        startRunAction.performed -= ctx => action();
    }
    //End Run
    public void SubscribeToEndRunEvent(System.Action action)
    {
        endRunAction.performed += ctx => action();
    }
    public void UnsubscribeToEndRunEvent(System.Action action)
    {
        endRunAction.performed -= ctx => action();
    }
    
    //toggleInventoryAction
    public void SubscribeToToggleInventoryEvent(System.Action action)
    {
        toggleInventoryAction.performed += ctx => action();
    }
    public void UnsubscribeToToggleInventoryEvent(System.Action action)
    {
        toggleInventoryAction.performed -= ctx => action();
    }

//Stream input handled actions
    public Vector2 GetMoveInput()
    {
        return moveAction.ReadValue<Vector2>();
    }
}
