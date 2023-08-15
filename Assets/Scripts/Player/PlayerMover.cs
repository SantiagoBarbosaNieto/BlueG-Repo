using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    Rigidbody2D player;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    //Method to be called to move 2D player
    public void Move(Vector2 moveVector)
    {
        //player.AddForce(moveVector);
        player.MovePosition(player.position + moveVector);
        
        //Flip sprite if direction is left or right
        if (moveVector.x > 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveVector.x < 0)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    

}
