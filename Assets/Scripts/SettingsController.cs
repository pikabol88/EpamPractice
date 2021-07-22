using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    private static SettingsController _instance;
    private Material _batMaterial;

    public static SettingsController Instanse
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

    public Material BatMaterial
    {
        get
        {
            return _batMaterial;
        }
        set
        {
            _batMaterial = value;
        }

    }

    protected void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }   
   
}
