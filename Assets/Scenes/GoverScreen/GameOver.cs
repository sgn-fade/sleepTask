using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnEnable()
    {
        Player.OnPlayerDead += OnPlayerDead;
    }
    

    private void OnDisable()
    {
        Player.OnPlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        animator.SetTrigger("main");
    }
}
