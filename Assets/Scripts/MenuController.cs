using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;

    public void StartGame()
    {
        menuPanel.SetActive(false);
    }
}
