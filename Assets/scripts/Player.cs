using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    private SpriteRenderer m_sprite;
    [SerializeField] private float actionCooldown = 0.3f;
    private float m_timeToAction;
    private static readonly int Attack1 = Animator.StringToHash("Attack1");
    private static readonly int Block = Animator.StringToHash("Block");


    private void Awake()
    {
        m_timeToAction = 0;
        m_animator = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        m_timeToAction -= Time.deltaTime;
        
        TryAttack();
        TryBlock();
    }

    private void TryRotate(float direction)
    {
        m_sprite.flipX = direction switch
        {
            < 0 => true,
            > 0 => false,
            _ => m_sprite.flipX
        };
        
    }
    private void TryAttack()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if (!(m_timeToAction <= 0) || direction == 0) return;
        
        m_animator.SetTrigger(Attack1);
        m_timeToAction = actionCooldown;
        TryRotate(direction);
    }

    private void TryBlock()
    {
        if (!(Input.GetAxisRaw("Vertical") > 0) || !(m_timeToAction <= 0)) return;
        
        m_animator.SetTrigger(Block);
        m_timeToAction = actionCooldown;

    }
}