using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
   // public AudioSource onBtnClickSound;
   // public AudioSource characterSound;

    [SerializeField] private AudioSource _audioSource;

    private static PlaySound _instance;
    private DictionarySoundsScript _soundsDict;

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
        _soundsDict = gameObject.GetComponent<DictionarySoundsScript>();
        //StartCoroutine(CharacterSound());
    }
    public void PlayOnBtnClickSound()
    {
        _audioSource.clip = _soundsDict.GetValue("OnBtnClick");
        _audioSource.Play();
    }

    public void PlayBatGoSound()
    {
        _audioSource.clip = _soundsDict.GetValue("LetsGo");
        _audioSource.Play();
    }

    public void PlayBatCollisionSound()
    {
        _audioSource.clip = _soundsDict.GetValue("BatAttack");
        _audioSource.Play();
    }

    public void PlayBatDestroySound()
    {
        _audioSource.clip = _soundsDict.GetValue("Destroy");
        _audioSource.Play();
    }

    public void PlayChickenDestroySound()
    {
        _audioSource.clip = _soundsDict.GetValue("Puf");
        _audioSource.Play();
    }

    public void PlayCharacterSound()
    {
        _audioSource.clip = _soundsDict.GetValue("Chicken");
        _audioSource.Play();
        StartCoroutine(CharacterSound());
    }

    private IEnumerator CharacterSound()
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        PlayCharacterSound();
    }

}
