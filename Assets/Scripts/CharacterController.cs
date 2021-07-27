using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : BaseCharacter
{
    public int livesAmount;
    public Text livesAmountText;
    public SkinnedMeshRenderer _mesh;

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
            else
            {
                Debug.Log(id);
                Boom();
                StartCoroutine(DestroyCharacter());
            }
        }
    }

    private IEnumerator DestroyCharacter()
    {       
        yield return new WaitForSeconds(0.2f);
        PlaySound.Instanse.PlayChickenDestroySound();
        _mesh.gameObject.SetActive(false);
        Boom();
        yield return new WaitForSeconds(0.4f);
        GameController.Instanse.OnCharacterDestroyed(id);
        this.gameObject.SetActive(false);
    }

    private void Boom()
    {
        var _particleSystem = GetComponentsInChildren<ParticleSystem>();
        Debug.Log(_particleSystem);
        foreach (var ps in _particleSystem)
        {
            Debug.Log(ps);
            ps.Play();
        }
    }
}
