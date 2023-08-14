
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{

    [Header("Configuration")]
    [SerializeField] public float speed = 5f;

    private PlayerInput playerInput { get => GetComponent<PlayerInput>(); }
    private PlayerMover playerMover { get => GetComponent<PlayerMover>(); }


    void Update()
    {
        Vector2 moveInput = playerInput.GetMoveInput();
        playerMover.Move(moveInput * speed * Time.deltaTime);
    }

    //

}
