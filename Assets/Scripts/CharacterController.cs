using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : BaseCharacter
{
    public int livesAmount;
    public Text livesAmountText;

    private void Start()
    {

        id = GetInstanceID();
        livesAmountText.text = (livesAmount).ToString();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Killer")
        {
            if (livesAmount > 1)
            {
                livesAmount--;
                livesAmountText.text = (livesAmount).ToString();
                return;
            }
            Debug.Log(id);
            gameObject.SetActive(false);
            GameController.Instanse.OnCharacterDestroyed(id);
            

        }
    }
}
