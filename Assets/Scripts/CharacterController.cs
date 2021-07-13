using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : BaseCharacter
{
    public int livesAmount;
    public TextMesh livesAmountText;
    private GameController _gameController;

    private void Start()
    {
        livesAmountText.text = (livesAmount).ToString();
        _gameController = FindObjectOfType<GameController>();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            if (livesAmount >= 1)
            {
                livesAmountText.text = (int.Parse(livesAmountText.text) - 1).ToString();
            }
            else
            {
                _gameController.OnCharacterDestroyed(id);
               
                gameObject.SetActive(false);
            }
        }
    }
}
