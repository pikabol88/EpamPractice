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
        customizationMenu.GetComponent<CustomizationPanelController>().enabled = false;

        mainMenu.SetActive(true);
    }

    public void DisplayCustomizationMenu()
    {
        customizationMenu.SetActive(true);
        customizationMenu.GetComponent<CustomizationPanelController>().enabled = true;

        mainMenu.SetActive(false);
    }
}
