using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    private SpriteRenderer m_sprite;
    [SerializeField] private float actionCooldown = 0.3f;
    private bool m_isAction = false;
    private float m_timeToAction;
    private static readonly int Attack1 = Animator.StringToHash("Attack1");
    private static readonly int Block = Animator.StringToHash("Block");


    private void Start()
    {
        m_timeToAction = 0;
        m_animator = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        m_timeToAction -= Time.deltaTime;
        
        TryRotate();
        TryAttack();
    }

    private void TryRotate()
    {
        if (m_isAction) return;
        float inputX = Input.GetAxis("Horizontal");
        m_sprite.flipX = inputX switch
        {
            < 0 => true,
            > 0 => false,
            _ => m_sprite.flipX
        };
    }
    private void TryAttack()
    {
        if (!(m_timeToAction <= 0)) return;
        if (Input.GetMouseButtonDown(0))
        {
            m_isAction = true;
            m_animator.SetTrigger(Attack1);
            m_timeToAction = actionCooldown;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            m_isAction = true;
            m_animator.SetTrigger(Block);
            m_timeToAction = actionCooldown;
        }

    }
}