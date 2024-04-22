using System.Collections;
using UnityEngine;

public class EntityHp : MonoBehaviour
{
    [SerializeField] private int entityHp = 0;

    public bool TakeDamage(int value)
    {
        if (value <= 0 || entityHp == 0) return false;
        entityHp -= value;
        return entityHp <= 0;

    }
    public void Heal(int value)
    {
        if (value <= 0) return;
        entityHp += value;
    }
    
    public int GetHp()
    {
        return entityHp;
    }
}
