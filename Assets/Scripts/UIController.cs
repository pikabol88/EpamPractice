using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
   
    public Text score;    

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
}
