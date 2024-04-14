using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHp : MonoBehaviour
{
    [SerializeField] private int entityHp = 0;

    public void TakeDamage(int value)
    {
        if (value <= 0) return;
        entityHp -= value;

        if (entityHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
