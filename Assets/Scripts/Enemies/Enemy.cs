using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Animator m_animator;
    [SerializeField] private int speed;
    [SerializeField] private EntityHp hpComponent;
    [SerializeField] private GameObject labelScore;

    [SerializeField] private bool isActive = true;
    private bool m_isHealing;
    
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Hurt = Animator.StringToHash("Hurt");

    private void Awake()
    {
        gameObject.tag = "Enemy";
        m_animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Player.Player.OnPlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        Player.Player.OnPlayerDead -= OnPlayerDead;
    }

    public bool TryGetHealing()
    {
        return m_isHealing;
    }
    private void OnPlayerDead()
    {
        isActive = false;
    }

    private void Start()
    {
        if (Random.Range(0, 100) < 20)
        {
            m_isHealing = true;
            GetComponent<Renderer>().material.color = new Color((float)0.6, 1, (float)0.5);
        }
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

    public bool TakeDamage(int value)
    {
        if (hpComponent.TakeDamage(value))
        {
            m_animator.SetTrigger(Death);
            SpawnScoreLabel();
            return true;
        }

        if (m_animator != null)
        {
            m_animator.SetTrigger(Hurt);
        }
        return false;
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
