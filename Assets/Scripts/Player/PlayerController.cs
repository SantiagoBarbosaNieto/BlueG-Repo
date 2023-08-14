using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] public float walkSpeed = 3f;
    [SerializeField] public float runSpeed = 5f;

    private float currentSpeed = 0f;
    
    //List of actions
    private List<Action> interactables;



    private PlayerInput playerInput { get => GetComponent<PlayerInput>(); }
    private PlayerMover playerMover { get => GetComponent<PlayerMover>(); }
    private PlayerAnimator playerAnimator { get => GetComponent<PlayerAnimator>();}

    private Collider2D playerCollider { get => GetComponent<Collider2D>(); }

    private void Awake()
    {
        playerInput.SubscribeToInteractEvent(OnInteractInput);
        playerInput.SubscribeToStartRunEvent(OnRunStartInput);
        playerInput.SubscribeToEndRunEvent(OnRunEndInput);
        currentSpeed = walkSpeed;
        interactables = new List<Action>();
    }

    void Update()
    {  
        CheckMoveInput(playerInput.GetMoveInput());
    }

    private void CheckMoveInput(Vector2 moveInput)
    {
        Vector2 moveVector = moveInput * 5*currentSpeed;
        playerMover.Move(moveVector*Time.deltaTime);
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
        playerAnimator.PlayInteractAnimation();
        
        //Only invoke the last action added to the list
        interactables[interactables.Count].Invoke();
        
    }

    internal void SubscribeInteractable(Action interact)
    {
        //Add action to the list
        interactables.Add(interact);
    }

    internal void UnsubscribeInteractable(Action interact)
    {
        //Remove action from the list
        interactables.Remove(interact);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickable"))
        {
            Debug.Log("Pickable");
        }
    }
}
