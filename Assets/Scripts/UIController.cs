using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   
    public Text score;    

    public GameObject resultLose;
    public GameObject resultWin;


    private static UIController _instance;

    public static UIController Instanse
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
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public void ChangeScore(int scoreNum)
    {
        score.text = $"Score: {scoreNum}";
    }

    public void DisplayWinPanel()
    {
        resultWin.SetActive(true);
    }

    public void DisplayLosePanel()
    {
        resultLose.SetActive(true);
    }
}
