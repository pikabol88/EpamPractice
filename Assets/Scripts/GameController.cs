using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Dictionary<int,EnemyController> _enemiesList = new Dictionary<int, EnemyController>();
    private Dictionary<int,CharacterController> _charactersList = new Dictionary<int, CharacterController>();

    public GameObject charactersContainer;
    public GameObject enemiesContainer;

    public GameObject pointForEnemy;
    public GameObject enemyPrefab;

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
        var characters = charactersContainer.GetComponentsInChildren<CharacterController>();
        foreach(var element in characters)
        {
            _charactersList.Add(element.id,element);
        }


        var enemies = enemiesContainer.GetComponentsInChildren<EnemyController>();
        foreach (var element in enemies)
        {
            _enemiesList.Add(element.id, element);
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

    public void OnEnemyDestroyed()
    {
        var enemyObject = Instantiate(enemyPrefab, enemiesContainer.transform);
        if (_enemiesList.Count == 0)
        {
            UIController.Instanse.DisplayLosePanel();
        }
    }
}
