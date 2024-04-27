using Enemies;
using UnityEngine;

namespace Scenes.PlayerSkill
{
    public class Skill : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(10);
                return;
            }

            if (other.GetComponent<Arrow>())
            {
                Destroy(other.gameObject);
            }
        }

        private void Delete()
        {
            Destroy(gameObject);
        }
    }
}
