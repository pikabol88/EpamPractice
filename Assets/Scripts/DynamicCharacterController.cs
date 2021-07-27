using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCharacterController : CharacterController
{
    public float speed;
    public int upBoarder = 55;
    public int bottomBoarder = 0;

    private Vector2 _moveVector;

    private void FixedUpdate()
    {
        MoveCharacter();

    }

    private void MoveCharacter()
    {
        if (transform.position.y >= upBoarder)
        {
            _moveVector = Vector2.down;
        }
        if (transform.position.y <= bottomBoarder)
        {
            _moveVector = Vector2.up;
        }
        transform.Translate(_moveVector * speed);
    }


}
