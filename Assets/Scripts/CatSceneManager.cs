using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _batMesh;
    [SerializeField] private GameObject _chickenMesh;

    [SerializeField] private GameObject _bat;
    [SerializeField] private Animator _batAnimator;
    [SerializeField] private GameObject _chicken;

    public void Move()
    {
        _batAnimator.SetBool("Move", true);
    }
    public void Attack()
    {
        _batAnimator.SetBool("Attack", true);
    }

    public void Destroy()
    {
        var effects1 = _bat.GetComponentsInChildren<ParticleSystem>();
        _batMesh.SetActive(false);
        var effects2 = _chicken.GetComponentsInChildren<ParticleSystem>();
        _chickenMesh.SetActive(false);

        PlaySound.Instanse.PlayBatDestroySound();

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
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }
}
