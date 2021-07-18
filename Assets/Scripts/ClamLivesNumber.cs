using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClamLivesNumber : MonoBehaviour
{
    public Text livesNumber;
    public GameObject livesPanel;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 livesNumberPos = _camera.WorldToScreenPoint(this.transform.position);
        livesPanel.transform.position = livesNumberPos;
        //livesNumber.transform.position = livesNumberPos;
    }
}
