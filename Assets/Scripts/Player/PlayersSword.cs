using System.Collections;
using UnityEngine;

public class PlayersSword : MonoBehaviour
{
    private ArrayList m_enemies;


    private void Awake()
    {
        m_enemies = new ArrayList();
    }

    public ArrayList GetEnemiesList()
    {
        return m_enemies;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() )
        {
            m_enemies.Add(other.GetComponent<Enemy>());
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            m_enemies.Remove(enemy);
        }
    }
}
