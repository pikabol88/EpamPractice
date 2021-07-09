using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int livesAmount;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
