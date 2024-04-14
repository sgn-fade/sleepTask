using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    private SpriteRenderer m_sprite;
    [SerializeField] private PlayersSword m_sword;
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
        transform.localScale = new Vector3(direction, 1, 1);

    }
    private void TryAttack()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if (!(m_timeToAction <= 0) || direction == 0) return;
        
        m_animator.SetTrigger(Attack1);
        m_timeToAction = actionCooldown;
        TryRotate(direction);

        foreach (GameObject enemy in m_sword.GetEnemiesList())
        {
            Destroy(enemy);
        }
    }

    private void TryBlock()
    {
        if (!(Input.GetAxisRaw("Vertical") > 0) || !(m_timeToAction <= 0)) return;
        
        m_animator.SetTrigger(Block);
        m_timeToAction = actionCooldown;

    }
}