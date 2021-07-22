using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource onBtnClickSound;

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

    public void PlayOnBtnClickSound()
    {
        onBtnClickSound.Play();
    }

}
