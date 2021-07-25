using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource onBtnClickSound;
    public AudioSource characterSound;

    private static PlaySound _instance;

    public static PlaySound Instanse
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameController: instanse not specified");
            }

            return _instance;
        }
    }


    protected void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(CharacterSound());
    }
    public void PlayOnBtnClickSound()
    {
        onBtnClickSound.Play();
    }

    public void PlayCharacterSound()
    {
        characterSound.Play();
        StartCoroutine(CharacterSound());
    }


    private IEnumerator CharacterSound()
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        PlayCharacterSound();
    }

}
