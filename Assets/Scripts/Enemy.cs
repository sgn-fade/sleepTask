using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    private Animator m_animator;
    [SerializeField] private int speed;
    [SerializeField] private EntityHp hpComponent;
    [SerializeField] private GameObject labelScore;


    [SerializeField] private bool isActive = true;
    
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Hurt = Animator.StringToHash("Hurt");

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

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
        speed = 0;
    }

    private void Update()
    {
        if (!isActive)
        {
            m_animator.SetInteger("AnimState", 0);
            return;
        }
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
        if (hpComponent.TakeDamage(value))
        {
            m_animator.SetTrigger(Death);
            SpawnScoreLabel();
            return;
        } 
        m_animator.SetTrigger(Hurt);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void SpawnScoreLabel()
    {
        Instantiate(labelScore, transform.position, Quaternion.identity);
    }
}
