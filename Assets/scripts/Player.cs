using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    
    [SerializeField] private PlayersSword sword;
    [SerializeField] private float actionCooldown = 0.04f;
    [SerializeField] private EntityHp hpComponent;
    [SerializeField] private PlayerUiHp hpUi;
    
    private float m_timeToAction;
    
    private static readonly int Attack1 = Animator.StringToHash("Attack1");
    private static readonly int Dodge = Animator.StringToHash("Roll");
    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Block = Animator.StringToHash("Block");

    public delegate void PlayerDeadDelegate();
    public static event  PlayerDeadDelegate OnPlayerDead;
        
    private void Awake()
    {
        m_timeToAction = 0;
        m_animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        m_timeToAction -= Time.deltaTime;
        TryRotate();
        TryAction();
    }

    private void Start()
    {
        hpUi.ChangeText(hpComponent.GetHp());
    }

    private void TryRotate()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        if (!(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) || direction == 0) return;
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private void TryAction()
    {
        if (m_timeToAction > 0)return;

        if (TryBlock() || TryDodge() || TryAttack())
        {
            m_timeToAction = actionCooldown;
        }
    }
    private bool TryAttack()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return false;
        m_animator.SetTrigger(Attack1);
        return true;

    }
    private bool TryDodge()
    {
        if (!Input.GetKeyDown(KeyCode.S)) return false;
        m_animator.SetTrigger(Dodge);
        return true;
    }
    private bool TryBlock()
    {
        if (!Input.GetKeyDown(KeyCode.W)) return false;
        m_animator.SetTrigger(Block);
        return true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            if (hpComponent.TakeDamage(1))
            {
                OnPlayerDead?.Invoke();
                Die();
            }
            hpUi.ChangeText(hpComponent.GetHp());
            m_animator.SetTrigger(Hurt);
        }
    }
    public void DealDamage()
    {
        foreach (Enemy enemy in sword.GetEnemiesList())
        {
            enemy.TakeDamage(1);
        }
    }
    
    private void Die()
    {
        m_animator.SetTrigger(Death);
    }
}