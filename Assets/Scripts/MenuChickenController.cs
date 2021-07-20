using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChickenController : MonoBehaviour
{
    private Animator _animator;
    private string _currentAnimation;

    public float repeat_time;
    private float _curr_time;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _curr_time = repeat_time;
    }
    void Update()
    {
        _curr_time -= Time.deltaTime;
        if (_curr_time <= 0)
        {
            StartRandomAnimation();
            _curr_time = repeat_time ;
        }
    }

    void StartRandomAnimation()
    {
        _animator.SetBool(_currentAnimation, false);
        _currentAnimation = _animator.parameters[Random.Range(0, _animator.parameters.Length)].name;
        _animator.SetBool(_currentAnimation, true);
    }
}
