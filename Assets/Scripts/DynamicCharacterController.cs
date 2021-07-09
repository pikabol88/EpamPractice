using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCharacterController : CharacterController
{
    public float speed;
    public int upBoarder;
    public int bottomBoarder;

    private Vector2 moveVector;

    private void FixedUpdate()
    {
        MoveCharacter();

    }

    private void MoveCharacter()
    {
        if (transform.transform.position.y >= upBoarder)
        {
            moveVector = Vector2.down;
        }
        if (transform.transform.position.y <= bottomBoarder)
        {
            moveVector = Vector2.up;
        }
        transform.Translate(moveVector * speed);
    }
    
}
