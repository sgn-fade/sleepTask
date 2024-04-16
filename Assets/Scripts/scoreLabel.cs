using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    
    [SerializeField] private GameObject ScoreUi;
    private void Start()
    {
        m_animator.SetTrigger("main");
    }

    public void Delete()
    {
        PlayerScore.UpdateScore(100);
        Destroy(gameObject);
    } 
}
