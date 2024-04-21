using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    private Animator m_animator;
    
    [SerializeField] private PlayersSword sword;
    [SerializeField] private float actionCooldown = 0.04f;
    [SerializeField] private float skillCooldown = 5f;
    [SerializeField] private EntityHp hpComponent;
    [SerializeField] private PlayerUiHp hpUi;

    [SerializeField] private GameObject skillScene;
    private double m_timeToAction;
    
    private static readonly int Attack1 = Animator.StringToHash("Attack1");
    private static readonly int Dodge = Animator.StringToHash("Roll");
    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Block = Animator.StringToHash("Block");
    private static readonly int Skill = Animator.StringToHash("Skill");

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
        skillCooldown -= Time.deltaTime;
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
        TryCast();
        TryBlock();
        TryDodge();
        TryAttack();
    }
    private void TryAttack()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
        m_animator.SetTrigger(Attack1);
        
    }
    private void TryDodge()
    {
        if (!Input.GetKeyDown(KeyCode.S)) return;
        m_animator.SetTrigger(Dodge);
    }
    private void TryBlock()
    {
        if (!Input.GetKeyDown(KeyCode.W)) return ;
        m_animator.SetTrigger(Block);
    }
    private void TryCast()
    {
        if (!Input.GetKeyDown(KeyCode.F) || skillCooldown <= 0) return ;
        Instantiate(skillScene, Vector3.zero, Quaternion.identity);
        m_animator.SetTrigger(Skill);
    }

    private void StartCooldown(float time)
    {
        if (time == 0)
        {
            time = actionCooldown;
        }
        m_timeToAction = time;
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