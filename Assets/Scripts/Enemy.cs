using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator m_animator;
    [SerializeField] private int speed;
    [SerializeField] private EntityHp hpComponent;
    private static readonly int Death = Animator.StringToHash("Death");

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
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

    public void TakeDamage(int value)
    {
        speed = 0;
        Debug.Log("die");
        m_animator.SetTrigger(Death);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
