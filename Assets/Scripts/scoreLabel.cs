using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Animator m_animator;

    private void Start()
    {
        m_animator.SetTrigger("main");
    }

    public void Delete()
    {
        //player score update
        Destroy(gameObject);
    } 
}
