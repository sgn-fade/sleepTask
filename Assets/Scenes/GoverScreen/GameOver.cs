using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject scoreObject;

    private Text scoreText;
    private void OnEnable()
    {
        Player.OnPlayerDead += OnPlayerDead;
    }

    private void Start()
    {
        scoreText = scoreObject.GetComponent<Text>();
    }

    private void OnDisable()
    {
        Player.OnPlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        animator.SetTrigger("main");
        scoreText.text = PlayerScore.GetScore().ToString();
    }
}
