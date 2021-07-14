using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : BaseCharacter
{
    public int livesAmount;
    public TextMesh livesAmountText;

    private void Start()
    {
        livesAmountText.text = (livesAmount).ToString();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (livesAmount > 1)
            {
                livesAmount--;
                livesAmountText.text = (livesAmount).ToString();
                return;
            }
            GameController.Instanse.OnCharacterDestroyed(id);               
            gameObject.SetActive(false);
        }
    }
}
