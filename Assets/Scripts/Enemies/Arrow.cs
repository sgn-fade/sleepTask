using UnityEngine;

namespace Enemies
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private bool isActive = true;
        [SerializeField] private int speed;
        private Vector2 m_velocity;
        private bool m_isParried;

        private void OnEnable()
        {
            Player.Player.OnPlayerDead += OnPlayerDead;
        }

        private void OnDisable()
        {
            Player.Player.OnPlayerDead -= OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            isActive = false;
        }

        private void Start()
        {
            gameObject.tag = "Enemy";
            Invoke(nameof(DestroyArrow), 4.0f);
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x, 1, position.z);
            transform1.position = position;
            m_velocity = transform1.forward * speed;
        }

        private void DestroyArrow()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (!isActive) return;
        
            transform.Translate(m_velocity * (Time.deltaTime * speed));
        }


        public void SetParried()
        {
            m_velocity.x *= -1;
            transform.localScale = new Vector3(m_velocity.x * 3, 3, 1);
            m_isParried = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy) && m_isParried)
            {
                enemy.TakeDamage(10);
                Destroy(gameObject);
            }
        }
    }
}