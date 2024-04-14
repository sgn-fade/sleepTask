using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator m_animator;
    private static readonly int Run = Animator.StringToHash("Idle");
    [SerializeField] private int speed = 0;
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        m_animator.SetTrigger("Idle");
    }

    private void Update()
    {
        m_animator.SetInteger("AnimState", 2);
        Vector2 direction = (Vector3.zero - transform.position).normalized;
        TryRotate(direction);
        transform.Translate(direction * (Time.deltaTime * speed));
    }
    private void TryRotate(Vector2 direction)
    {
        transform.localScale = new Vector3(-Mathf.Sign(direction.x), 1, 1);
    }
}
