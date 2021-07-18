using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Dictionary<int,KillerController> _killersList = new Dictionary<int, KillerController>();
    private Dictionary<int,CharacterController> _charactersList = new Dictionary<int, CharacterController>();

    public CharacterController[] characters;
    public KillerController[] killers;

    public GameObject killerPrefab;

    public int baseScore;
    private int _currentScore = 0;

    private static GameController _instance;

    public static GameController Instanse
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

    protected void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }

    void Start()
    {
        foreach(var element in characters)
        {
            _charactersList.Add(element.id,element);
        }


        foreach (var element in killers)
        {
            _killersList.Add(element.id, element);
        }

    }

    public void OnCharacterDestroyed(int id)
    {
        var character = _charactersList[id];
        Debug.Log(character);
        _currentScore = _currentScore + character.livesAmount * baseScore;
        Debug.Log(_currentScore);
        UIController.Instanse.ChangeScore(_currentScore);
        _charactersList.Remove(id);

        if (_charactersList.Count == 0)
        {
            UIController.Instanse.DisplayWinPanel();
        }
    }

    public void OnKillerDestroyed()
    {
        var enemyObject = Instantiate(killerPrefab);
        if (_killersList.Count == 0)
        {
            UIController.Instanse.DisplayLosePanel();
        }
    }
}