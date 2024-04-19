using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private int speed;
    private Vector2 m_velocity;
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
        isActive = false;
    }

    private void Start()
    {
        gameObject.tag = "Enemy";
        
        var transform1 = transform;
        
        var position = transform1.position;
        position.y = 1;
        transform1.position = position;

        m_velocity = new Vector2(Vector2.zero.x - position.x, 0).normalized;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }
        TryRotate(m_velocity);
        transform.Translate(m_velocity * (Time.deltaTime * speed));
    }
    private void TryRotate(Vector2 direction)
    {
        transform.localScale = new Vector3(Mathf.Sign(direction.x) * 3, 3, 1);
    }
}
