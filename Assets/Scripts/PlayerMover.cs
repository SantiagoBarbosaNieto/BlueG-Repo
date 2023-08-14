using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Transform player;

    public float speed = 5f;

    private void Awake()
    {
        player = GetComponent<Transform>();
    }

    //Method to be called to move 2D player
    public void Move(Vector2 direction)
    {
        player.Translate(direction);
        
        //Flip sprite if direction is left or right
        if (direction.x > 0)
        {
            player.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            player.localScale = new Vector3(-1, 1, 1);
        }
    }
    

}
