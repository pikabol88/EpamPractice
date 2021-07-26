using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _batMesh;
    [SerializeField] private GameObject _chickenMesh;

    [SerializeField] private GameObject _bat;
    [SerializeField] private GameObject _chicken;

    public void Destroy()
    {
        var effects1 = _bat.GetComponentsInChildren<ParticleSystem>();
        _batMesh.SetActive(false);
        var effects2 = _chicken.GetComponentsInChildren<ParticleSystem>();
        _chickenMesh.SetActive(false);
        foreach (var element in effects1)
        {
            element.Play();            
        }
        foreach (var element in effects2)
        {
            element.Play();
        }
        StartCoroutine(StartGame());

    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
