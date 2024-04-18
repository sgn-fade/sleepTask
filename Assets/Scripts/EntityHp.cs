using System.Collections;
using UnityEngine;

public class EntityHp : MonoBehaviour
{
    [SerializeField] private int entityHp = 0;

    public bool TakeDamage(int value)
    {
        if (value <= 0) return false;
        entityHp -= value;
        return entityHp <= 0;

    }

    public int GetHp()
    {
        return entityHp;
    }
}
