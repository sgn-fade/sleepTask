using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scenes.GoverScreen
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject scoreObject;

        private Text m_scoreText;
        private void OnEnable()
        {
            Player.Player.OnPlayerDead += OnPlayerDead;
        }

        private void Start()
        {
            m_scoreText = scoreObject.GetComponent<Text>();
        }

        private void OnDisable()
        {
            Player.Player.OnPlayerDead -= OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            animator.SetTrigger("main");
            m_scoreText.text = PlayerScore.GetScore().ToString();
        }

        public void OnRetryPressed()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            PlayerScore.Reset();
        }

        public void OnQuitPressed()
        {
            Application.Quit();
        }
    }
}
