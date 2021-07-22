using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Terrain _terrain;

    private Dictionary<int,KillerController> _killersList = new Dictionary<int, KillerController>();
    private Dictionary<int,CharacterController> _charactersList = new Dictionary<int, CharacterController>();

    public CharacterController[] characters;
    public KillerController[] killers;

    public GameObject killerPrefab;

    public int baseScore;
    private int _currentScore = 0;
    private int _currentKiller = 0;

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
            Debug.Log(element.id);
            _charactersList.Add(element.id,element);
        }


        foreach (var element in killers)
        {
            Debug.Log(element.id);
            _killersList.Add(element.id, element);
            element.Mesh.material = SettingsController.Instanse.BatMaterial;
        }

        for(int i = 1;i< killers.Length; i++)
        {
            (killers[i]).gameObject.SetActive(false);
        }

    }

    public void OnCharacterDestroyed(int id)
    {
        var character = _charactersList[id];
        _currentScore = _currentScore + character.livesAmount * baseScore;
        UIController.Instanse.ChangeScore(_currentScore);
        _charactersList.Remove(id);

        if (_charactersList.Count == 0)
        {
            UIController.Instanse.DisplayWinPanel();
        }
    }

    public void OnKillerDestroyed()
    {
        if(_currentKiller < killers.Length-1)
        {
            _currentKiller++;
            (killers[_currentKiller]).gameObject.SetActive(true);
        }
        else
        {
            UIController.Instanse.DisplayLosePanel();
        }
    }

    public void KillerOnPress(bool state)
    {
        _terrain.GetComponent<TerrainCollider>().enabled = state;
    }
}