using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject customizationMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void DisplayMainMenu()
    {
        customizationMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void DisplayCustomizationMenu()
    {
        customizationMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
