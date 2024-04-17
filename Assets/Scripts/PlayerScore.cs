using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private static int playerScore = 0;

    [SerializeField] private GameObject textObj;
    private static Text m_textLabel;
    private void Start()
    {
        m_textLabel = textObj.GetComponent<Text>();
    }

    public static void UpdateScore(int value)
    {
        playerScore += value;
        Debug.Log(playerScore);
        m_textLabel.text = playerScore.ToString();
    }

    public static int GetScore()
    {
        return playerScore;
    }
}
